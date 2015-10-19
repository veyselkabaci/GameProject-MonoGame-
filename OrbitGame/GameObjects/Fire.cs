using HologramSpriteManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitGame.GameObjects
{
    class Fire : AnimatedSprite
    {
        public Fire(AnimatedSpriteSequences Meta)
            : base(Meta)            {
            
        }

        public Fire()
        {

        }

        public int bIsUp = 1;
        public bool hit = false;

        public void Update()
        {
            if (bIsUp==1)
                Position.X -= 4;
            else if (bIsUp == 2)
                Position.X += 4;
            else if (bIsUp == 3)
                Position.Y -= 4;
            else if(bIsUp == 4)
                Position.Y += 4;
        }

        public void Initialize()
        {
        }

    }
}
