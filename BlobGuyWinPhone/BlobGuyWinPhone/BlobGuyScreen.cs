using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _4Engine.Screens;

namespace PyroclasticStudios
{
    public class BlobGuyScreen : Screen
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

        public BlobGuyScreen(Game1 theGame)
        {
            _theGame = theGame;
        }
    }
}
