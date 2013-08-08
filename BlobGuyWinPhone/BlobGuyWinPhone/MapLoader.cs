using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using _4Engine.Helpers;
using _4Engine.Managers;

namespace PyroclasticStudios
{
    public class MapLoader : BaseClass
    {
        #region privates
        private Game1 _theGame;
        private Texture2D _tileTex;
        private Texture2D _movingPTex;
        private Texture2D _playerTex;
        private Texture2D _badGuyTex;
        private Texture2D _lavaTex;
        private Texture2D _portalTex;
        private Texture2D _lazerTex;
        private Texture2D _spaceTileTex;
        private Texture2D _checkpointTex;
        private Texture2D _leftBtnTex;
        private Texture2D _rightBtnTex;
        private Texture2D _upBtnTex;
        List<ScreenButton> _buttons;
        #endregion

        #region internal properties
        internal Game1 TheGame
        {
            get { return _theGame; }
        }
        public Texture2D PlayerTexture
        {
            get{ return _playerTex; }
        }
        internal List<ScreenButton> Buttons
        {
            get { return _buttons; }
        }
        #endregion

        public MapLoader(Game1 theGame)
        {
            _theGame = theGame;
        }

        public const float TILE_SIZE = 64;
        public static int HeightInTiles;
        public static int WidthInTiles;

        public void LoadContent()
        {
            _playerTex = TheGame.CommonContent.Load<Texture2D>("Images\\blobman");
            _tileTex = TheGame.CommonContent.Load<Texture2D>("Images\\tile");
            _movingPTex = TheGame.CommonContent.Load<Texture2D>("Images\\movingplatform");
            _lavaTex = TheGame.CommonContent.Load<Texture2D>("Images\\lava");
            _lazerTex = TheGame.CommonContent.Load<Texture2D>("Images\\lazer");
            _portalTex = TheGame.CommonContent.Load<Texture2D>("Images\\portal");
            _spaceTileTex = TheGame.CommonContent.Load<Texture2D>("Images\\spacetile");
            _checkpointTex = TheGame.CommonContent.Load<Texture2D>("Images\\checkpoint");
            _badGuyTex = TheGame.CommonContent.Load<Texture2D>("Images\\evilguy");
            _leftBtnTex = Content.Load<Texture2D>(@"GameButtons\arrowleft");
            _rightBtnTex = Content.Load<Texture2D>(@"GameButtons\arrowright");
            _upBtnTex = Content.Load<Texture2D>(@"GameButtons\arrowup");
        }

        public List<Sprite> MakeMap(Texture2D map)
        {
            List<Sprite> objects = new List<Sprite>();
            WidthInTiles = map.Width;
            HeightInTiles = map.Height;

            Color[] colors = new Color[map.Width * map.Height];
            map.GetData(colors);

            for (int idx = 0; idx < map.Width; ++idx)
            {
                for (int idy = 0; idy < map.Height; ++idy)
                {
                    Vector2 position = new Vector2(idx * TILE_SIZE, idy * TILE_SIZE);

                    Color color = colors[idx + idy * map.Width];
                    if (color == Color.White)
                    {
                        Platform p = new Platform(TheGame, _tileTex, position);
                        objects.Add(p);

                    }
                    else if (color == Color.Red)
                    {
                        Lava l = new Lava(TheGame, _lavaTex, position);
                        objects.Add(l);
                    }
                    else if (color == Color.Aqua)
                    {
                        Player p = new Player(TheGame, _playerTex, position);
                        GameScreen.ActiveGame.Player = p;
                        objects.Add(p);
                    }
                    else if (color == Color.Yellow)
                    {
                        Portal p = new Portal(TheGame, _portalTex, position);
                        objects.Add(p);
                    }
                    else if (color == Color.Blue)
                    {
                        BadGuy b = new BadGuy(TheGame, position, _badGuyTex);
                        objects.Add(b);
                    }
                    else if (color == Color.Purple)
                    {
                        MovingPlatform m = new MovingPlatform(TheGame, _movingPTex, position);
                        objects.Add(m);
                    }
                    else if (color == Color.Gray)
                    {
                        Lazers l = new Lazers(TheGame, _lazerTex, position);
                        objects.Add(l);

                    }
                    else if (color == Color.YellowGreen)
                    {
                        SpaceTile sp = new SpaceTile(TheGame, _spaceTileTex, position);
                        objects.Add(sp);
                    }
                    else if (color == Color.HotPink)
                    {
                        Checkpoint cp = new Checkpoint(TheGame, position, _checkpointTex);
                        objects.Add(cp);
                    }
                }
            }

            _buttons = new List<ScreenButton>();
            _buttons.Add(new ScreenButton(TheGame, _leftBtnTex, new Vector2(0, FourGame.Height - _leftBtnTex.Height), ButtonAction.Left));
            _buttons.Add(new ScreenButton(TheGame, _rightBtnTex, new Vector2(FourGame.Width - _rightBtnTex.Width, FourGame.Height - _rightBtnTex.Height), ButtonAction.Right));
            _buttons.Add(new ScreenButton(TheGame, _upBtnTex, new Vector2(0, FourGame.Height - (_leftBtnTex.Height + _upBtnTex.Height)), ButtonAction.Up));
            _buttons.Add(new ScreenButton(TheGame, _upBtnTex, new Vector2(FourGame.Width - _upBtnTex.Width, FourGame.Height - (_rightBtnTex.Height + _upBtnTex.Height)), ButtonAction.Up));
            objects.AddRange( _buttons.Cast<Sprite>() );
            return objects;
        }
    }
}
