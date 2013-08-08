using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace punchaface
{
    public class Checkpoint : Sprite
    {
        public Checkpoint(Game1 theGame, Vector2 position, Texture2D texture)
            : base(theGame, texture, position)
        {
        }
    }
}
