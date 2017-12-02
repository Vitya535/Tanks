﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    class BuilderForPlayerTank : Builder
    {
        Tank product = new Tank();
        Random rnd = new Random();

        public override void BuildHealth()
        {
            product.Add(100);
        }

        public override void BuildCartridge()
        {
            product.Add(new CartridgeInTank(Cartridge.TypeOfCartridges.Medium, 25, 4));
        }

        public override void BuildSpeed()
        {
            product.Add(1.25);
        }

        public override void BuildStrategy()
        {
            product.Add(new StrategyForPlayer());
        }

        public override void BuildState()
        {
            product.Add(new StateAlive());
        }

        // указать координаты поля здесь в рандоме
        public override void SetCoordX()
        {
            product.Add(rnd.Next());
        }

        public override void SetCoordY()
        {
            product.Add(rnd.Next());
        }

        public override Tank GetResult()
        {
            return product;
        }
    }
}
