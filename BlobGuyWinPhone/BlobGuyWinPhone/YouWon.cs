using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using _4Engine.Core.Controls;
using Microsoft.Xna.Framework.Graphics;

namespace PyroclasticStudios
{
    public class YouWon : MenuBase
    {
        Texture2D background;
        public YouWon(Game1 theGame) : base(theGame)
        {
        }

        public override void LoadContent()
        {
            background = Content.Load<Texture2D>("background");
            _4Button mainMenu = Add("Main Menu");
            mainMenu.Clicked += delegate
            {
                CurrentScreen = new MenuScreen(TheGame);
            };
            Buttons.Add(mainMenu);
            base.LoadContent();
        }

        public override void Draw()
        {
            const string youWon = "You Won!";
            Vector2 size = Font.MeasureString(youWon);

            SpriteBatch.Begin();
            SpriteBatch.Draw(background, new Rectangle(0, 0, GameWidth, GameHeight), Color.White);
            SpriteBatch.DrawString(Font, youWon, new Vector2(GameWidth / 2f, GameHeight / 2f) - size, Color.White, 0f, Vector2.Zero, 2f, Microsoft.Xna.Framework.Graphics.SpriteEffects.None, 0f);
            SpriteBatch.End();
            base.Draw();
        }
    }
}
