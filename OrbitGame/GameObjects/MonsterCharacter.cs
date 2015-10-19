using HologramSpriteManager;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitGame.GameObjects
{
    class MonsterCharacter : AnimatedSprite
    {
        public MonsterCharacter(AnimatedSpriteSequences Meta)
            : base(Meta) 
        {
        }

        public bool died = false;

        public void Update(Point p)
        {

            if(Position.X < p.X)
            {
                Position.X += 1;
            }
            if (Position.X > p.X)
            {
                Position.X -= 1;
            }
            if (Position.Y < p.Y)
            {
                Position.Y += 1;
            }
            if (Position.Y > p.Y)
            {
                Position.Y -= 1;
            }
        }

        public Point getRandomPoint() 
        {
            Random rnd = new Random();
            int xPos = rnd.Next(800);
            int yPos = rnd.Next(600);
            Point rndPoint = new Point(xPos,yPos);
            return rndPoint;
        }
    }


}
