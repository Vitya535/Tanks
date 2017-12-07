using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace BLForTankGame
{
    public abstract class Artifact : IArtifactsOnField
    {
        protected readonly int x;
        protected readonly int y;
        protected Image objectImage;
        public int GetX { get { return x; } }
        public int GetY { get { return y; } }
        public Image ObjectImage { get { return objectImage; } }

        public Artifact(int artX, int artY)
        {
            x = artX;
            y = artY;
        }

        public virtual void CauseEffect(Tank tank)
        {}    
    }

    class RepairKit : Artifact
    {
        public RepairKit(int artX, int artY) : base(artX, artY)
        {
            objectImage = ImagesForGame.GetRepairKit;
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
            objectImage = ImagesForGame.GetDamageUp;
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
            objectImage = ImagesForGame.GetRangeUp;
        }

        public override void CauseEffect(Tank tank)
        {
            tank.TankCartridge.Range++;
        }
    }
}
