using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _4Engine.Screens;
using _4Engine.Core.Controls;
using Microsoft.Xna.Framework;
using _4Engine.Managers;
using _4Engine.Helpers;

namespace PyroclasticStudios
{
    public class PauseScreen : MenuBase
    {
        public PauseScreen(Game1 game)
            : base(game)
        {
        }

        public override void LoadContent()
        {
            _4Button resume = Add("Resume");
            resume.Clicked += delegate
            {
                ScreenManager.RemoveScreen(this);
            };
            Buttons.Add(resume);
            _4Button mainMenu = Add("Main Menu");
            mainMenu.Clicked += delegate
            {
                CurrentScreen = new MenuScreen(TheGame);
            };
            Buttons.Add(mainMenu);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw()
        {
            SpriteBatch.Begin();


            SpriteBatch.End();

            base.Draw();
        }
    }
}
