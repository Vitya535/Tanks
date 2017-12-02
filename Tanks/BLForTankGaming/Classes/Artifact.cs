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
        protected int x; // возможно private
        protected int y;  // возможно private
        protected Image objectImage;  // возможно private
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image GetObjectImage { get { return objectImage; } }
        private List<IObserver> observers;

        public Artifact()
        {
            observers = new List<IObserver>();
        }

        public Artifact(int artX, int artY)
        {
            x = artX;
            y = artY;
        }

        public virtual void CauseEffect(Tank tank)
        {
            tank.Artifacts.Add(this);
        }

        public void AddObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver()
        {
            observers = null;
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
        {  }

        public override void CauseEffect(Tank tank)
        {
            base.CauseEffect(tank);
            tank.Health += 30;
        }
    }

    class IncreaseDamage : Artifact
    {
        public IncreaseDamage(int artX, int artY) : base(artX, artY)
        { }

        public override void CauseEffect(Tank tank)
        {
            base.CauseEffect(tank);
            tank.TankCartridge.Damage += 5;
        }
    }

    class IncreaseRange : Artifact
    {
        public IncreaseRange(int artX, int artY) : base(artX, artY)
        { }

        public override void CauseEffect(Tank tank)
        {
            base.CauseEffect(tank);
            tank.TankCartridge.Range++;
        }
    }
}
