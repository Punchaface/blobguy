using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace punchaface
{
    public class Platform : Sprite
    {
        public Platform(Game1 theGame, Texture2D tile, Vector2 pos)
            : base(theGame, tile, pos)
        {
        }
    }
}
