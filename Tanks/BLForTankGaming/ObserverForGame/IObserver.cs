using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface IObserver
    {
        void UpdateMoveRight(Tank ob);
        void UpdateMoveLeft(Tank ob);
        void UpdateMoveUp(Tank ob);
        void UpdateMoveDown(Tank ob);
        void UpdateShoot(Tank ob);
    }
}
