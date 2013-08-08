using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;

namespace PyroclasticStudios
{

    public class ScreenButton : Sprite
    {
        ButtonAction _action;
        Rectangle _rect;
        public ScreenButton(Game1 theGame, Texture2D texture, Vector2 position, ButtonAction action)
            : base(theGame, texture, position )
        {
            _action = action;
            _rect = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        }

        public ButtonAction Action
        {
            get { return _action; }
        }

        public bool IsPressed(TouchCollection touched)
        {
            bool pressed = false;
            foreach (TouchLocation loc in touched)
            {
                if (loc.State == TouchLocationState.Pressed && _rect.Contains((int)loc.Position.X, (int)loc.Position.Y))
                {
                    pressed = true;
                    break;
                }
            }
            return pressed;
        }

        public bool IsPressed(MouseState state)
        {
            bool pressed = false;
            if (state.LeftButton == ButtonState.Pressed && _rect.Contains(state.X, state.Y))
            {
                pressed = true;
            }
            return pressed;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }
        /// <summary>
        /// Draws the sprite at the specific position and offsets them by scrollpos, the camera position
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="scrollPos"></param>
        public override void Draw(SpriteBatch spriteBatch, Vector2 scrollPos)
        {
            spriteBatch.Draw(Texture, Position, Color.White);
        }
    }
}
