using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public class Tank : ITanks // реализовать паттерн "Строитель", "Стратегия", "Состояние"
    {
        private int x;
        private int y;
        private Image image;
        private int health;
        private readonly int movementSpeed; // если будет что-то что будет влиять на скорость, то readonly убрать (возможно это поле вообще не нужно)
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image GetObjectImage { get { return image; } }
        public int GetHealth { get { return health; } }
        public int GetMoveSpeed { get { return movementSpeed; } }
        public Cartridge TankCartridge { get; private set; }
        public List<Artifact> Artifacts { get; private set; }
        public IStrategy Strategy { private get; set; }

        public void UseStrategy()
        {
            Strategy.TacticAlgorithm();
        }
    }
}
