using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface IStrategy // для паттерна "стратегия"
    {
        void TacticAlgorithm();
    }
}
