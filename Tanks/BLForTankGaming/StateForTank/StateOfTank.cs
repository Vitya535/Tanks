using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public abstract class StateOfTank
    {
        public abstract void ChangeState(Tank tank); // вот не знаю пока точно туда танк передавать или нет?
    }
}
