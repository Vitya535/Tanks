using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public class Tank : ITanks, IObservable // реализовать паттерн "Строитель", "Стратегия", "Состояние"
    {
        private int x;
        private int y;
        private Image image;
        private int health;
        private readonly int movementSpeed; // если будет что-то что будет влиять на скорость, то readonly убрать (возможно это поле вообще не нужно)
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image GetObjectImage { get { return image; } }
        public int Health { get { return health; } set { health = value; } }
        public int GetMoveSpeed { get { return movementSpeed; } }
        public Cartridge TankCartridge { get; private set; }
        public List<Artifact> Artifacts { get; private set; } // возможно это нафиг не нужно, при моих созданных непереносимыых танком артефактах
        public IStrategy Strategy { private get; set; }
        public StateOfTank State { get; set; }
        private List<IObserver> observers;

        List<object> parts = new List<object>();
        public void Add(object part)
        {
            parts.Add(part);
        }

        public Tank()
        {
            observers = new List<IObserver>();
        }

        public void UseStrategy()
        {
            Strategy.TacticAlgorithm();
        }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
                observer.Update(); // добавить в Update все что нужно
        }
    }
}
