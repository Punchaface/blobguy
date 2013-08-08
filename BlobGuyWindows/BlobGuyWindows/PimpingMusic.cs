using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Media;

namespace punchaface
{
    class PimpingMusic
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

        public PimpingMusic(Game1 theGame)
        {
            _theGame = theGame;
        }

        public void PlayRandom()
        {
            MediaPlayer.Play(GetRandomSong());
            MediaPlayer.MediaStateChanged += new EventHandler<EventArgs>(MediaStateChanged);
        }

        
        void MediaStateChanged(object sender, EventArgs e)
        {
            if (MediaPlayer.State == MediaState.Stopped)
            {
                PlayNextRandom();
            }
        }

        private void PlayNextRandom()
        {
            MediaPlayer.Play(GetRandomSong());
        }

        public Song GetRandomSong()
        {
            Random rand = new Random();
            int songIndex = rand.Next(6);
            string song = string.Format("Music\\ingame{0}", songIndex);
            return TheGame.CommonContent.Load<Song>(song);
        }
    }
}
