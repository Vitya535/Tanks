using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public abstract class Artifact : IArtifactsOnField // здесь применить паттерн "адаптер"
    {
        protected int x; // возможно private
        protected int y;  // возможно private
        protected Image objectImage;  // возможно private
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image GetObjectImage { get { return objectImage; } }

        public Artifact(int artX, int artY)
        {
            x = artX;
            y = artY;
        }

        public virtual void CauseEffect(Tank tank)
        { }// ???? как оказать эффект на танк?
    }

    class RepairKit : Artifact
    {
        public RepairKit(int artX, int artY) : base(artX, artY)
        {  }

        public override void CauseEffect(Tank tank)
        {
            tank.Artifacts.Add(); // добавить тот артефакт, который стоит на этих координатах
            tank. // с модификаторами доступа разобраться (к характеристикам не могу добраться)
            // какой-то эффект на танке (пока не реализован класс танка)
        }
    }

    class IncreaseDamage : Artifact
    {
        public IncreaseDamage(int artX, int artY) : base(artX, artY)
        { }

        public override void CauseEffect(Tank tank)
        {
            tank.Artifacts.Add(); // добавить тот артефакт, который стоит на этих координатах
            // с модификаторами доступа разобраться (к характеристикам не могу добраться)
            // какой-то эффект на танке (пока не реализован класс танка)
        }
    }

    class IncreaseRange : Artifact
    {
        public IncreaseRange(int artX, int artY) : base(artX, artY)
        { }

        public override void CauseEffect(Tank tank)
        {
            tank.Artifacts.Add(); // добавить тот артефакт, который стоит на этих координатах
            // с модификаторами доступа разобраться (к характеристикам не могу добраться)
            // какой-то эффект на танке (пока не реализован класс танка)
        }
    }
}
