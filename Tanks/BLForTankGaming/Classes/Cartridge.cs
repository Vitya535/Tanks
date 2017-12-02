using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public abstract partial class Cartridge : ICartridges // использовать паттерн "Цепочка обязанностей" (если он будет вообще нужен)
    {
        protected TypeOfCartridges Type { get; set; } // тип снарядов
        public int Damage { get { return damage; } set { damage = value; } } // урон снарядов
        public int Range { get { return range; } set { range = value; } } // дальность полета снаряда
        protected int damage; // пока до конца не уверен что readonly (надо о нем побольше узнать) 
        protected int range; // пока до конца не уверен что readonly (надо о нем побольше узнать) 

        public Cartridge(TypeOfCartridges type, int dmg, int ranged)
        {
            Type = type;
            damage = dmg;
            range = ranged;
        }

        // возможно здесь должен быть метод что-то вроде "нанести урон" для паттерна "цепочка обязанностей" (или этот метод должен быть у игры?)
    }


    public class CartridgeInTank : Cartridge // класс для патронов конкретно в танке, паттерн "цепочка обязанностей" реализовать
    {
        public CartridgeInTank(TypeOfCartridges type, int dmg, int ranged) : base(type, dmg, ranged)
        { }
    }

    public class CartridgeOnField : Cartridge, IObjectsOnField
    {
        private Image objectImage;
        private int x;
        private int y;
        public Image GetObjectImage { get { return objectImage; } }
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }

        public CartridgeOnField(TypeOfCartridges type, int dmg, int ranged) : base(type, dmg, ranged)
        { }
    }
}
