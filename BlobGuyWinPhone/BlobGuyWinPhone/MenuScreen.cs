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
using System.IO.IsolatedStorage;

namespace PyroclasticStudios
{
    public class MenuScreen : MenuBase
    {
        PimpingMusic _pimp;
        _4Button _continueG;
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

            _continueG = Add("Continue Game");
            _continueG.Clicked = ContinueClicked;

            _4Button exit = Add("Exit");
            exit.Clicked += delegate
            {
                FourGame.Game.Exit();
            };
            Buttons.Add(exit);

            _pimp.PlayRandom();
            base.LoadContent();
        }

        private void ContinueClicked(object sender, EventArgs e)
        {
            BinaryReader reader = null;
#if WINDOWS_PHONE
            IsolatedStorageFile isoFile = IsolatedStorageFile.GetUserStoreForApplication();
            if (isoFile.FileExists(LevelFinished.FileName))
            {
                reader = new BinaryReader(new IsolatedStorageFileStream(LevelFinished.FileName, FileMode.Open, isoFile));
            }
#else
            if (File.Exists(LevelFinished.FileName))
            {
                reader = new BinaryReader(File.OpenRead(LevelFinished.FileName));
            }
#endif
            if(reader != null)
            {
                Player.LevelNumber = reader.ReadInt32();
                Player.Deaths = reader.ReadInt32();
                reader.Close();
            }
            else
            {
                _continueG.Text = "No Saves!";
            }
            CurrentScreen = new GameScreen(TheGame);
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
