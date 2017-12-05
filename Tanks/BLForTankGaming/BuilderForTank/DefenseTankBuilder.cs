using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    class DefenseTankBuilder : Builder
    {
        Tank product = new Tank();
        Random rnd = new Random();

        public override void BuildHealth()
        {
            product.Add(100);
        }

        public override void BuildCartridge()
        {
            product.Add(new CartridgeInTank(Cartridge.TypeOfCartridges.Light, 20, 4));
        }

        public override void BuildStrategy()
        {
            product.Add(new DefenseStrategy());
        }

        public override void BuildState()
        {
            product.Add(new StateAlive());
        }

        public override void SetCoordX()
        {
            product.Add(rnd.Next(1, 31));
        }

        public override void SetCoordY()
        {
            product.Add(rnd.Next(1, 21));
        }

        public override void SetStartImage()
        {
            product.Add(Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/AIDown.jpg"));
        }

        public override Tank GetResult()
        {
            product.CreateResult();
            return product;
        }
    }
}
