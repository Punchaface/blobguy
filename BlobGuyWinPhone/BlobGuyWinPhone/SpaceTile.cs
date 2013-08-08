using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PyroclasticStudios
{
    public class SpaceTile : Sprite
    {
        public SpaceTile(Game1 theGame, Texture2D spacetile, Vector2 pos)
            : base(theGame, spacetile, pos)
        {
        }
    }
}
