using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _4Engine.Core.Controls;
using _4Engine.Managers;
using System.IO;

namespace punchaface
{
    public class LevelFinished : MenuBase
    {
        public const string FileName = "system32.notsavefile";

        public LevelFinished(Game1 game) : base(game)
        {
            BinaryWriter bw = new BinaryWriter(File.Create(FileName));
            bw.Write(Player.LevelNumber);
            bw.Write(Player.Deaths);
            bw.Close();
        }

        public override void LoadContent()
        {
            _4Button next = Add("Next Level");
            next.Clicked += delegate
            {
                ScreenManager.RemoveScreen(this);
            };
            Buttons.Add(next);
            _4Button mainMenu = Add("Main Menu");
            mainMenu.Clicked += delegate
            {
                CurrentScreen = new MenuScreen(TheGame);
            };
            Buttons.Add(mainMenu);
            base.LoadContent();
        }
    }
}
