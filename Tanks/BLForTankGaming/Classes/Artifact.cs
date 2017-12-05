using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public abstract class Artifact : IArtifactsOnField, IObservable// здесь применить паттерн "адаптер"
    {
        protected readonly int x; // возможно private
        protected readonly int y;  // возможно private
        protected Image objectImage;  // возможно private
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image ObjectImage { get { return objectImage; } }
        private IObserver observer;

        public Artifact()
        {
            observer = null;
        }

        public Artifact(int artX, int artY)
        {
            x = artX;
            y = artY;
        }

        public virtual void CauseEffect(Tank tank)
        {}

        public void AddObserver(IObserver o)
        {
            observer = o;
        }

        public void RemoveObserver()
        {
            observer = null;
        }

        public void NotifyObserver()
        {
            //foreach (IObserver observer in observers)
                //observer.Update(); // добавить в Update все что нужно
        }       
    }

    class RepairKit : Artifact
    {
        public RepairKit(int artX, int artY) : base(artX, artY)
        {
            objectImage = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/health.jpg");
        }

        public override void CauseEffect(Tank tank)
        {
            tank.Health += 30;
        }
    }

    class IncreaseDamage : Artifact
    {
        public IncreaseDamage(int artX, int artY) : base(artX, artY)
        {
            objectImage = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/damage.jpg");
        }

        public override void CauseEffect(Tank tank)
        {
            tank.TankCartridge.Damage += 5;
        }
    }

    class IncreaseRange : Artifact
    {
        public IncreaseRange(int artX, int artY) : base(artX, artY)
        {
            objectImage = Image.FromFile("C:/Users/Виктор/Desktop/Университет/3семестр/Tanks/Tanks/Images/range.jpg");
        }

        public override void CauseEffect(Tank tank)
        {
            tank.TankCartridge.Range++;
        }
    }
}
