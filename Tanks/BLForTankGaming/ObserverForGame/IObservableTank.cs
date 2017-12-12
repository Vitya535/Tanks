using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    interface IObservableTank : IObservable
    {
        void NotifyObserverForMove(Tank.Direction dir);
        void NotifyObserverForShoot();
    }
}
