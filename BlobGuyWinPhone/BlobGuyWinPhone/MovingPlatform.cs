using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PyroclasticStudios
{
    public class MovingPlatform : Platform
    {
        /// <summary>
        /// The distance in platforms that the platform moves in each direction
        /// </summary>
        public const float PLATFORMS_TO_MOVE = 1;
        /// <summary>
        /// The speed that the platforms moves at in pixels a second
        /// </summary>
        public const float SPEED = 100;

        private Vector2 leftMost;
        private Vector2 rightMost;

        private bool movingLeft;

        public MovingPlatform(Game1 theGame, Texture2D tex, Vector2 pos)
            : base(theGame, tex, pos)
        {
            leftMost = Position - new Vector2(PLATFORMS_TO_MOVE*MapLoader.TILE_SIZE, 0);
            rightMost = Position + new Vector2(PLATFORMS_TO_MOVE*MapLoader.TILE_SIZE, 0);
        }

        public override void Update(GameTime gameTime)
        {
            if (movingLeft)
            {
                Position.X -= SPEED*(float) gameTime.ElapsedGameTime.TotalSeconds;
                if (Position.X < leftMost.X)
                    movingLeft = false;
            }
            else
            {
                Position.X += SPEED * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (Position.X > rightMost.X)
                    movingLeft = true;
            }
            base.Update(gameTime);
        }
    }
}
