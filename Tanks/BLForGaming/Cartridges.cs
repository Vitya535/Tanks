﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLForInterfaces;
using System.Drawing;

namespace BLClassesForGame
{
    abstract class Cartridge : ICartridges
    {
        public enum TypeOfCartridges { Light, Medium, Heavy } // перечисляемый тип для типов снарядов, мне кажется надо будет здесь поправить дело с доступом
        protected TypeOfCartridges Type { get; set; } // тип снарядов
        public int GetDamage { get { return damage; } } // урон снарядов
        public int GetRange { get { return range; } } // дальность снарядов
        protected int damage; // пока до конца не уверен что readonly (надо о нем побольше узнать) 
        protected int range; // пока до конца не уверен что readonly (надо о нем побольше узнать) 

        public Cartridge(TypeOfCartridges type, int dmg, int ranged)
        {
            Type = type;
            damage = dmg;
            range = ranged;
        }
    }


    class CartridgeInTank : Cartridge // класс для патронов конкретно в танке, паттерн "цепочка обязанностей" реализовать
    {
        public CartridgeInTank(TypeOfCartridges type, int dmg, int ranged) : base(type, dmg, ranged)
        { }
    }

    class CartridgeOnField : Cartridge, IObjectsOnField
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
