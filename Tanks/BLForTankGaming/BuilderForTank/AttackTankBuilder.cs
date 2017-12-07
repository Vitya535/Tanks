using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    class AttackTankBuilder : Builder
    {
        Tank product = new Tank();
        //Random rnd = new Random();

        public override void BuildCartridge()
        {
            product.Add(new CartridgeInTank(Cartridge.TypeOfCartridges.Heavy, 30, 5));
        }

        public override void BuildStrategy()
        {
            product.Add(new AttackStrategy());
        }

        public override void SetCoordX()
        {
            product.Add(GetRndOne.Next(1, 26));
        }

        public override void SetCoordY()
        {
            product.Add(GetRndOne.Next(1, 26));
        }

        public override void SetStartImage()
        {
            product.Add(ImagesForGame.GetTankAIDown);
        }

        public override Tank GetResult()
        {
            product.CreateResult();
            return product;
        }
    }
}
