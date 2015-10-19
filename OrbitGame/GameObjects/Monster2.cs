using HologramSpriteManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitGame.GameObjects
{
    class Monster2 : AnimatedSprite
    {
        public Monster2(AnimatedSpriteSequences Meta)
            : base(Meta) 
        {
        }

        public bool died = false;

        public void Update()
        {
            Position.Y += 1;
        }

    }
}
