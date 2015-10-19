using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using HologramSpriteManager;
using OrbitGame.GameObjects;

namespace OrbitGame
{

    class PlayerCharacter : AnimatedSprite
    {
        
        public PlayerCharacter(AnimatedSpriteSequences Meta)
            : base(Meta){}

        public PlayerCharacter()
        {

        }

        public static int x = 1;
        public static bool a = true;


        public Point Update()
        {
            if (a)
            {
                Position.X = 380;
                Position.Y = 200;
                a = false;
            }
            if(Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                if(Position.X > 10)
                {
                        Position.X -= 3;
                }
                    
                ChangeAnimation("walkleft", false);
                PlayerCharacter.x = 1;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                if (Position.X < 790)
                {
                        Position.X += 3;
                }
                    
                ChangeAnimation("walkright", false);
                PlayerCharacter.x = 2;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                if (Position.Y > 10)
                {
                        Position.Y -= 3;
                }
                    
                ChangeAnimation("walkup", false);
                PlayerCharacter.x = 3;
            }
            else if(Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                if (Position.Y < 430)
                {
                        Position.Y += 3;
                }
                    
                ChangeAnimation("walkdown", false);
                PlayerCharacter.x = 4;
            }
            else
            {
                ChangeAnimation("idle");
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                GameStatic.Shoot(PlayerCharacter.x, (int)Position.X + 10, (int)Position.Y+20, 0);
            }
            


            int x = (int)Math.Ceiling(Position.X);
            int y = (int)Math.Ceiling(Position.Y);
            Point p = new Point(x,y);
            return p;
        }

    }
}
