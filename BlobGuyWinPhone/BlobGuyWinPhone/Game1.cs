using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _4Engine.Managers;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PyroclasticStudios
{
    public class Game1 : FourGame
    {
        private ContentManager _commonContent;

        public ContentManager CommonContent
        {
            get { return _commonContent; }
        }

        public Game1()
            :base("Game")
        {
            _commonContent = new ContentManager(Services, "BlobGuyCommonContent");
            Content.RootDirectory = "Content";
            FourGame.Game = this;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        public GameScreen Screen
        {
            get
            {
                GameScreen scr = null;
                if (CurrentScreen is GameScreen)
                {
                    scr = (GameScreen)CurrentScreen;
                }
                return scr;
            }
        }

        protected override void LoadContent()
        {
            ScreenManager.Font = _commonContent.Load<SpriteFont>("Fonts\\Font");

            Lava.Particles = new Texture2D[]
            {
                _commonContent.Load<Texture2D>("Images\\bubble1"),
                _commonContent.Load<Texture2D>("Images\\bubble2"),
                _commonContent.Load<Texture2D>("Images\\bubble1"),
            };

            CurrentScreen = new MenuScreen(this);
            base.LoadContent();
        }

        protected override void Draw(Microsoft.Xna.Framework.GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
