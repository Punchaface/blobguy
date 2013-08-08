using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace punchaface
{
    public class Lazers : Sprite
    {

        public Lazers(Game1 theGame, Texture2D tex, Vector2 pos)
            : base (theGame, tex, pos){ }
    }
}
