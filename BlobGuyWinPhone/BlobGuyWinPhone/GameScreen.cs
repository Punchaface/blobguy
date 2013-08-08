using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using _4Engine.Screens;
using _4Engine;
using _4Engine.Managers;
using _4Engine.Core._2D;

namespace PyroclasticStudios
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class GameScreen : BlobGuyScreen
    {
        public static GameScreen ActiveGame; //this is a singleton, this is good use of statics

        public const float MAX_PAR = 500;

        public List<Sprite> GameObjects = new List<Sprite>();
        public List<Particle> Particles = new List<Particle>();
        public Vector2 ScrollPos;
        public Player Player;
        public bool _loadNextLevel = false;
        MapLoader _maps;

        #region static contents
        public static SoundEffect Die;
        public static SoundEffect FinishLevel;
        public static SoundEffect Jump;
        public static SoundEffect SaveGame;
        #endregion

        #region Textures
        Texture2D background;
        Texture2D spacebackground;
        #endregion

        public GameScreen(Game1 game) : base(game)
        {
            ActiveGame = this;
            _maps = new MapLoader(TheGame);
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        public override void LoadContent()
        {
            FourEngine.ChangeGraphics(800, 480);
            _maps.LoadContent();

            #region sounds
            Die = TheGame.CommonContent.Load<SoundEffect>("Sounds\\DieSound");
            FinishLevel = TheGame.CommonContent.Load<SoundEffect>("Sounds\\Fanfare");
            SaveGame = TheGame.CommonContent.Load<SoundEffect>("Sounds\\savesound");
            Jump = TheGame.CommonContent.Load<SoundEffect>("Sounds\\JumpSound");
            #endregion

            #region backgrounds
            background = TheGame.CommonContent.Load<Texture2D>("Images\\background");
            spacebackground = TheGame.CommonContent.Load<Texture2D>("Images\\spacebackground");
            #endregion

            Player = new Player(TheGame, _maps.PlayerTexture, Vector2.Zero);

            _loadNextLevel = true;
        }

        public void LoadLevel(string level)
        {
            _loadNextLevel = true;
        }

        public List<ScreenButton> Buttons
        {
            get
            {
                return _maps.Buttons;
            }
        }


        public override void Update(GameTime gameTime)
        {
            //humm so this will update every element in the game
            for (int idx = 0; idx < GameObjects.Count; idx++)
            {
                GameObjects[idx].Update(gameTime);
            }

            for (int i = 0; i < Particles.Count; ++i)
            {
                Particles[i].Update(gameTime);

                if (Particles[i].Dead() || Particles.Count > MAX_PAR)
                {
                    Particles.RemoveAt(i);
                    i--;
                }
            }

            if (_loadNextLevel)
            {
                GameObjects.Clear();
                try
                {
                    GameObjects = _maps.MakeMap(Content.Load<Texture2D>("Maps\\map" + Player.LevelNumber));
                }
                catch
                {
                    CurrentScreen = new YouWon(TheGame);
                }
                _loadNextLevel = false;
            }

            ScrollPos = Vector2.Lerp(ScrollPos, -Player.Position + new Vector2(400 - 32, 240 - 32), 0.3f);
            
            base.Update(gameTime);

            if (Input.IsPressed(Keys.Escape))
            {
                ScreenManager.AddScreen(new PauseScreen(TheGame));
            }
        
        }



        
      

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        //protected override void UnloadContent()
    

        public override void Draw()
        {
            SpriteBatch.Begin();

            Texture2D bgkGround;
            if (Player.LevelNumber >= 9 && Player.LevelNumber <= 15)
            {
                bgkGround = spacebackground;
            }
            else
            {
                bgkGround = background;
            }


            SpriteBatch.Draw(
                bgkGround, 
                new Rectangle(0,0, Game1.Width,Game1.Height)
                , Color.White
            );
            

            if (Player != null)
                 Player.DrawHUD(SpriteBatch);
            foreach (Particle p in Particles)
                p.Draw(SpriteBatch, ScrollPos);
            foreach (Sprite s in GameObjects)
                s.Draw(SpriteBatch, ScrollPos);
            

            

            SpriteBatch.End();

            base.Draw();
        }
    }
}
