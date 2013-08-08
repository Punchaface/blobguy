using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using _4Engine.Helpers;
using punchaface;

namespace BlobGuyWindows
{
    public class Spikes : Sprite
    {
        public Spikes(Game1 theGame, Texture2D tile, Vector2 pos)
        : base(theGame, tile, pos)
        {
        }

    }
}
