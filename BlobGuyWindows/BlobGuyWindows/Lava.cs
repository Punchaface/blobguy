using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using _4Engine.Helpers;

namespace punchaface
{
    public class Lava : Sprite
    {
        public static Texture2D[] Particles;

        public Lava(Game1 theGame, Texture2D tex, Vector2 pos)
            : base(theGame, tex, pos)
        { }

        public override void Update(GameTime gameTime)
        {
            if (Vector2.Distance(Position, GameScreen.ActiveGame.Player.Position) < 900 && Util.RandomFloat() > 0.9f)
            {
                Particle p = new Particle(TheGame, Position + new Vector2(GetRect.Width / 2f, 0), Particles[Util.Random(2)]);
                p.RoationVelocity = Util.RandomFloat();
                p.Velocity = Util.RandomDirection() * 3;
                GameScreen.ActiveGame.Particles.Add(p);
            }
            base.Update(gameTime);
        }
    }
}
