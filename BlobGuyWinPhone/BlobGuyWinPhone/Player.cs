using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using _4Engine.Managers;
using _4Engine.Core.Controls;
using Microsoft.Xna.Framework.Input.Touch;

namespace PyroclasticStudios
{
    public class Player : Sprite
    {
        private Vector2 spawnPos;
        private Vector2 velocity;
        private TimeSpan _lastLevelSwitched;
        public static int Deaths = 0; //why you static?, Because coop is not intended
        public static int LevelNumber = 4; //why you static?, Only one instance of the level number is ever needed
        

        public Player(Game1 theGame, Texture2D texture, Vector2 position)
            : base(theGame, texture, position)
        {
            spawnPos = position;
        }


        public override void Update(GameTime gameTime)
        {
            KeyboardState keys = Keyboard.GetState();

            Vector2 oldPos = Position;
            ButtonAction actions = ButtonAction.None;

            if (TheGame.Screen != null)
            {
                TouchCollection touched = TouchPanel.GetState();
                TheGame.Screen.Buttons.ForEach(
                    delegate(ScreenButton btn)
                    { if (btn.IsPressed(touched)) actions |= btn.Action; }
                );
            }

            if (keys.IsKeyDown(Keys.D) || actions.IsRight())
                velocity.X+=2;
            if (keys.IsKeyDown(Keys.A) || actions.IsLeft())
                velocity.X-=2;

            Position.X += velocity.X;
            if (OnPlatform(gameTime))
                Position.X = oldPos.X;

            Position.Y += velocity.Y;
            if (OnPlatform(gameTime))
            {
                velocity.Y = 0;
                Position.Y = oldPos.Y;

                if (keys.IsKeyDown(Keys.W) || actions.IsUp())
                {
                    velocity.Y = -12f;
                    GameScreen.Jump.Play();
                    if( Player.LevelNumber >= 9 && Player.LevelNumber <= 15 )
                    {
                        velocity.Y = -18f;
                    }
                }
            }
            else 
            { 
                velocity.Y += 0.5f; 
            }

            velocity.X /= 1.4f;

            if (Position.Y > MapLoader.HeightInTiles * MapLoader.TILE_SIZE + 300)
            {
                KillPlayer();
            }

            base.Update(gameTime);
        }

        private void KillPlayer()
        {
            Position = spawnPos;
            velocity = Vector2.Zero;
            GameScreen.Die.Play();
            Deaths++;
        }

        private bool OnPlatform(GameTime gameTime)
        {
            Sprite whatHit = null;
            bool onPlatform = false;
            //go through every game element.
            Rectangle playerRect = GetRect;
            foreach (Sprite gameElement in GameScreen.ActiveGame.GameObjects)
            {
                if (gameElement == this) continue; //it's me ignore
                
                //if the element is not this player and it's touching another element
                //work out which element it's touching and do something

                //this is not a very reliable way of detecting collisions
                //there seem to be some funny behaviour  
                if (playerRect.Intersects(gameElement.GetRect))
                {
                    whatHit = gameElement;
                    if (gameElement is Platform) //touching a platform; good
                    {
                        onPlatform = true;
                        break;
                    }
                    else if (gameElement is SpaceTile)
                    {
                        onPlatform = true;
                        break;
                    }
                    else if (gameElement is Lava) //touching lava; die!!
                    {
                        onPlatform = false;
                        KillPlayer();
                        break;
                    }
                    else if (gameElement is Lazers)
                    {
                        onPlatform = false;
                        KillPlayer();
                        break;
                    }
                    else if (gameElement is BadGuy)
                    {
                        KillPlayer();
                    }
                    else if (gameElement is Checkpoint)
                    {
                        spawnPos = gameElement.Position;
                        //GameScreen.SaveGame.Play();

                    }
                    else if (gameElement is Portal)
                    {
                        //level hysterysis
                        //if it's more than 5 secs since the last level switch
                        //then switch level. Otherwise assume that the level switch hasn't happened yet
                        if (_lastLevelSwitched == null || (gameTime.TotalGameTime - _lastLevelSwitched).TotalSeconds > 5)
                        {
                            _lastLevelSwitched = gameTime.TotalGameTime;
                            LevelNumber++;
                            ScreenManager.AddScreen(new LevelFinished(TheGame));

                            GameScreen.FinishLevel.Play();

                            System.Diagnostics.Debug.WriteLine("Level number = {0}", LevelNumber);
                            GameScreen.ActiveGame._loadNextLevel = true;
                            break;
                        }
                    }
                }
            }

            if (!onPlatform)//not touching anything
            {
                //System.Diagnostics.Debug.WriteLine("At {0}, Hit nothing ", gameTime.ElapsedGameTime.TotalSeconds);
            }
            else
            {
                //System.Diagnostics.Debug.WriteLine("At {0}, Hit {1} ", gameTime.ElapsedGameTime.TotalSeconds, whatHit.GetType().Name);
            }

            return onPlatform;
        }

        public void DrawHUD(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(GameScreen.Font, "Deaths: " + Deaths, new Vector2(20), Color.Black);
            spriteBatch.DrawString(GameScreen.Font, "Level: " + (LevelNumber + 1), new Vector2(20, 50), Color.Black);
        }
    }
}
