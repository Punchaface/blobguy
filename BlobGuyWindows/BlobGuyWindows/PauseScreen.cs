using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _4Engine.Screens;
using _4Engine.Core.Controls;
using Microsoft.Xna.Framework;
using _4Engine.Managers;
using _4Engine.Helpers;
using Microsoft.Xna.Framework.Media;

namespace punchaface
{
    public class PauseScreen : MenuBase
    {
        public bool isMusicMuted = false;
        PimpingMusic _pimp;
        public PauseScreen(Game1 game)
            : base(game)
        {
            _pimp = new PimpingMusic(game);
        }

        public override void LoadContent()
        {
            _4Button resume = Add("Resume");
            resume.Clicked += delegate
            {
                ScreenManager.RemoveScreen(this);
            };
            Buttons.Add(resume);

            _4Button mainMenu = Add("Main Menu");
            mainMenu.Clicked += delegate
            {
                CurrentScreen = new MenuScreen(TheGame);
            };
            _4Button randomsong = Add("Random Song");
            randomsong.Clicked += delegate
            {
                MediaPlayer.Play(_pimp.GetRandomSong());
            };
            Buttons.Add(mainMenu);

            _4Button muteMusic = Add("Mute Music");
            muteMusic.Clicked += delegate
            {
                if (isMusicMuted == false)
                {
                    MediaPlayer.Pause();
                    isMusicMuted = true;
                    System.Diagnostics.Debug.WriteLine("Paused Music!");
                }
                else
                {
                    MediaPlayer.Resume();
                    isMusicMuted = false;
                    System.Diagnostics.Debug.WriteLine("Unpaused Music!");
                }
            };
            Buttons.Add(muteMusic);

            //_4Button unMuteMusic = Add("Unmute Music");
            //unMuteMusic.Clicked += delegate
            //{
                //MediaPlayer.Resume();
                //isMusicMuted = false;
                //System.Diagnostics.Debug.WriteLine("Unmuted Music!");
            //};
            //Buttons.Add(unMuteMusic);
            
            base.LoadContent();

        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);
        }

        public override void Draw()
        {
            SpriteBatch.Begin();


            SpriteBatch.End();

            base.Draw();
        }
    }
}
