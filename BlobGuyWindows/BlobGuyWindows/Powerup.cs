using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using punchaface;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BlobGuyWindows
{
    public class Powerup : Sprite
    {     
        public Powerup(Game1 theGame, Texture2D tile, Vector2 pos)
            : base(theGame, tile, pos)
        {
        }

    }
}
