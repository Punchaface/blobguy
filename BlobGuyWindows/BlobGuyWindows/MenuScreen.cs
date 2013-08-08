using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _4Engine.Screens;

using _4Engine.Core.Controls;
using Microsoft.Xna.Framework;
using _4Engine.Helpers;
using _4Engine.Managers;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using Microsoft.Xna.Framework.Media;

namespace punchaface
{
    public class MenuScreen : MenuBase
    {
        PimpingMusic _pimp;
        public MenuScreen(Game1 theGame) : base(theGame)
        {
            _pimp = new PimpingMusic(theGame);
        }

        Texture2D bg;

        public override void LoadContent()
        {
            bg = TheGame.CommonContent.Load<Texture2D>("Images\\menubackground");

            _4Button play = Add("New Game");
            play.Clicked += delegate
                {
                    Player.Deaths = 0;
                    Player.LevelNumber = 0;
                    CurrentScreen = new GameScreen(TheGame);

                };
            Buttons.Add(play);

#if WINDOWS_PHONE
            //todo investigate save file I/O for windows phone
#else
            _4Button continueG = Add("Continue Game");
            continueG.Clicked += delegate
            {
                if (File.Exists(LevelFinished.FileName))
                {
                    BinaryReader br = new BinaryReader(File.OpenRead(LevelFinished.FileName));
                    Player.LevelNumber = br.ReadInt32();
                    Player.Deaths = br.ReadInt32();
                    br.Close();
                    CurrentScreen = new GameScreen(TheGame);
                }
                else
                    continueG.Text = "No Saves!";
            };
            Buttons.Add(continueG);
#endif

            _4Button exit = Add("Exit");
            exit.Clicked += delegate
            {
                FourGame.Game.Exit();
            };
            Buttons.Add(exit);

            _pimp.PlayRandom();
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw()
        {
            SpriteBatch.Begin();

            SpriteBatch.Draw(bg, new Rectangle(0, 0, GameWidth, GameHeight), Color.White);

            SpriteBatch.End();

            base.Draw();
        }
    }
}
