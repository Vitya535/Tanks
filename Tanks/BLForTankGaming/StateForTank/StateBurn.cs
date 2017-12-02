using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    class StateBurn : StateOfTank
    {
        public override void ChangeState(Tank tank)
        {
            if (tank.Health > 50)
            {
                tank.State = new StateAlive();
                tank.Strategy = new AttackStrategy();
            }
        }
    }
}
