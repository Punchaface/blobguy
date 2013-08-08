using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using _4Engine.Helpers;
using BlobGuyWindows;

namespace punchaface
{
    public class MapLoader
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

        public MapLoader(Game1 theGame)
        {
            _theGame = theGame;
        }

        public const float TILE_SIZE = 64;
        public static int HeightInTiles;
        public static int WidthInTiles;
        public static Texture2D TileTex;
        public static Texture2D MovingPTex;
        public static Texture2D SpikesTex;
        public static Texture2D PlayerTex;
        public static Texture2D BadGuyTex;
        public static Texture2D LavaTex;
        public static Texture2D PortalTex;
        public static Texture2D LazerTex;
        public static Texture2D SpaceTileTex;
        public static Texture2D CheckpointTex;
        public static Texture2D FlowerTex;
        public static Texture2D PowerupTex;
        public static Texture2D DirtTex;

        public void MakeMap(out List<Sprite> objects, Texture2D map)
        {
            objects = new List<Sprite>();
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
                        Platform p = new Platform(TheGame, TileTex, position);
                        objects.Add(p);

                    }
                    else if (color == Color.Red)
                    {
                        Lava l = new Lava(TheGame, LavaTex, position);
                        objects.Add(l);
                    }
                    else if (color == Color.Aqua)
                    {
                        Player p = new Player(TheGame, PlayerTex, position);
                        GameScreen.ActiveGame.Player = p;
                        objects.Add(p);
                    }
                    else if (color == Color.Yellow)
                    {
                        Portal p = new Portal(TheGame, PortalTex, position);
                        objects.Add(p);
                    }
                    else if (color == Color.Blue)
                    {
                        BadGuy b = new BadGuy(TheGame, position, BadGuyTex);
                        objects.Add(b);
                    }
                    else if (color == Color.Purple)
                    {
                        MovingPlatform m = new MovingPlatform(TheGame, MovingPTex, position);
                        objects.Add(m);
                    }
                    else if (color == Color.Gray)
                    {
                        Lazers l = new Lazers(TheGame, LazerTex, position);
                        objects.Add(l);

                    }
                    else if (color == Color.YellowGreen)
                    {
                        SpaceTile sp = new SpaceTile(TheGame, SpaceTileTex, position);
                        objects.Add(sp);
                    }
                    else if (color == Color.HotPink)
                    {
                        Checkpoint cp = new Checkpoint(TheGame, position, CheckpointTex);
                        objects.Add(cp);
                    }
                    else if (color == Color.Orange)
                    {
                        Spikes sk = new Spikes(TheGame, SpikesTex, position);
                        objects.Add(sk);
                    }
                    else if (color == Color.Gold)
                    {
                        Flower fl = new Flower(TheGame, FlowerTex, position);
                        objects.Add(fl);
                    }
                    else if (color == Color.Cyan)
                    {
                        Powerup pu = new Powerup(TheGame, PowerupTex, position);
                        objects.Add(pu);
                    }
                    else if (color == Color.Brown)
                    {
                        Dirt dt = new Dirt(TheGame, DirtTex, position);
                        objects.Add(dt);
                    }
                }
            }
        }
    }
}
