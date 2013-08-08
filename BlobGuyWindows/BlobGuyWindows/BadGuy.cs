using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace punchaface
{
    public class BadGuy : Sprite
    {
        const float SPEED = .9f;

        private Vector2 velocity;
        private float dir;

        public BadGuy(Game1 theGame, Vector2 position, Texture2D texture)
            : base(theGame, texture, position)
        {
            Random rand = new Random();
            dir = rand.NextDouble() > 0.5f ? -1 : 1;
        }

        public override void Update(GameTime gameTime)
        {
            Vector2 oldPos = Position;
            velocity.X += 1 * dir;

            Position.X += velocity.X;
            if (Hit())
            {
                Position.X = oldPos.X;
                dir *= -1;
            }

            Position.Y += velocity.Y;
            if (Hit())
            {
                Position.Y = oldPos.Y;
                velocity.Y = 0;
            }
            else { velocity.Y += 0.1f; }
            velocity.X /= 1.4f;
            base.Update(gameTime);
        }

        private bool Hit()
        {
            foreach (var sprite in GameScreen.ActiveGame.GameObjects)
            {
                if (sprite != this && !(sprite is Player))
                {

                    if (sprite.GetRect.Intersects(GetRect))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 scrollPos)
        {
            base.Draw(spriteBatch, scrollPos);
        }
    }
}
