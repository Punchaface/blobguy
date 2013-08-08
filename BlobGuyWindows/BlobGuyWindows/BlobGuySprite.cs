using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _4Engine.Helpers;

namespace punchaface
{
    public class BlobGuySprite : BaseClass
    {
        #region privates
        private Game1 _theGame;
        #endregion

        #region internal properties
        internal Game1 TheGame
        {
            get { return _theGame; }
        }
        #endregion

        public BlobGuySprite(Game1 theGame)
        {
            _theGame = theGame;
        }
    }
}
