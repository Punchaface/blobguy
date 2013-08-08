using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using _4Engine.Helpers;

namespace punchaface
{
    public class Sprite : BlobGuySprite
    {
        public Texture2D Texture;
        public Vector2 Position;

        public virtual Rectangle GetRect
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            }
        }

        public Sprite(Game1 theGame, Texture2D texture, Vector2 position) : base(theGame)
        {
            Texture = texture;
            Position = position;
        }

        /// <summary>
        /// Updates
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Draws the sprite at the specific position and offsets them by scrollpos, the camera position
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="scrollPos"></param>
        public virtual void Draw(SpriteBatch spriteBatch, Vector2 scrollPos)
        {
            spriteBatch.Draw(Texture, Position + scrollPos, Color.White);
        }
    }
}
