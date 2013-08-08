using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace punchaface
{
    public class Particle : Sprite
    {
        public Particle(Game1 theGame, Vector2 position, Texture2D texture)
            : base(theGame, texture, position)
        {
        }

        public Vector2 Origin
        {
            get { return new Vector2(Texture.Width / 2f, Texture.Height / 2f); }
        }

        public float Rotation;
        public float Scale = 1f;
        public float RoationVelocity;
        public Vector2 Velocity;
        public Color Tint = Color.White;

        public override void Update(GameTime gameTime)
        {
            if (Dead()) return;

            Rotation += RoationVelocity;
            RoationVelocity /= 1.5f;

            Position += Velocity;
            Velocity.X /= 1.4f;
            Velocity.Y += 0.1f;

            int a = Tint.A;
            a -= (int)2;
            if (Tint.A > 0)
                Tint.A = (byte)a;
            else
                Tint.A = 0;
            base.Update(gameTime);
        }

        public bool Dead()
        {
            return Tint.A <= 0 || Velocity.Y > 3;
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 scrollPos)
        {
            spriteBatch.Draw(Texture, Position + scrollPos, null, Tint, Rotation, Origin, Scale, SpriteEffects.None, 0f);
        }
    }
}
