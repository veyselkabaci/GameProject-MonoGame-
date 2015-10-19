using HologramSpriteManager;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitGame.GameObjects
{
    class MonsterCharacter1 : AnimatedSprite
    {
        public MonsterCharacter1(AnimatedSpriteSequences Meta)
            : base(Meta) 
        {
            
            Position = new Vector2(500, 500);
        }

        public void Update(Point x)
        {
            
            if(Position.X < x.X)
            {
                Position.X += 1;
            }
            if (Position.X > x.X)
            {
                Position.X -= 1;
            }
            if (Position.Y < x.Y)
            {
                Position.Y += 1;
            }
            if (Position.Y > x.Y)
            {
                Position.Y -= 1;
            }
        }

    }
}
