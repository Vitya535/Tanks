using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLForInterfaces;
using System.Drawing;

namespace BLClassesForGame
{
    abstract class Artifact : IArtifactsOnField // здесь применить паттерн "адаптер"
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

        public virtual void CauseEffect()
        { }// ???? как оказать эффект на танк?
    }

    class RepairKit : Artifact
    {
        public RepairKit(int artX, int artY) : base(artX, artY)
        {  }

        public override void CauseEffect()
        {
            base.CauseEffect();
            // какой-то эффект на танке (пока не реализован класс танка)
        }
    }

    class IncreaseDamage : Artifact
    {
        public IncreaseDamage(int artX, int artY) : base(artX, artY)
        { }

        public override void CauseEffect()
        {
            base.CauseEffect();
            // какой-то эффект на танке (пока не реализован класс танка)
        }
    }

    class IncreaseRange : Artifact
    {
        public IncreaseRange(int artX, int artY) : base(artX, artY)
        { }

        public override void CauseEffect()
        {
            base.CauseEffect();
            // какой-то эффект на танке (пока не реализован класс танка)
        }
    }
}
