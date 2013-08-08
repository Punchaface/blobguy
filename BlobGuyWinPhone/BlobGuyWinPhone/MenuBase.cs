using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _4Engine.Screens;
using _4Engine.Core.Controls;
using Microsoft.Xna.Framework;
using _4Engine.Helpers;

namespace PyroclasticStudios
{
    public class MenuBase : BlobGuyScreen
    {
        public MenuBase(Game1 game)
            : base(game)
        {
        }

        public List<_4Button> Buttons = new List<_4Button>();

        public override void Update(GameTime gameTime)
        {
            foreach (var b in Buttons)
                b.Update(gameTime);

            base.Update(gameTime);
        }

        public _4Button Add(string text)
        {
            const int bWidth = 256;
            const int bHeight = 64;
            Vector2 pos = new Vector2(GameWidth / 2f - bWidth / 2f, 20 + (20 + bHeight) * Buttons.Count);
            _4Button button = new _4Button();
            button.Text = text;
            button.Position = pos;
            button.Width = bWidth;
            button.Height = bHeight;
            button.Texture = Util.CreateTexture(256, 64, Color.White, Color.LightGray, 10, Shape.Square);

            return button;
        }

        public override void Draw()
        {
            SpriteBatch.Begin();

            foreach (var b in Buttons)
                b.Draw();

            SpriteBatch.End();
            base.Draw();
        }
    }
}
