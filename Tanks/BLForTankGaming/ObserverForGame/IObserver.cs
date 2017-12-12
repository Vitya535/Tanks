using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface IObserver
    {
        void UpdateMove(Tank ob, Tank.Direction dir);
        void UpdateShoot(Tank ob);
    }
}
