using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using punchaface;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace BlobGuyWindows
{
    public class Flower : Sprite
    {
        public Flower(Game1 theGame, Texture2D tile, Vector2 pos)
            : base(theGame, tile, pos)
    {
    }

    }
}
