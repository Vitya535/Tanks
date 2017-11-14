using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface IObstaclesOnField : IObjectsOnField // интерфейс для препятствий
    {
        int Health { get; } // здоровье препятствия (если оно есть), если оно неразрушимое значит будет значение NaN (или просто ноль), или что-то вроде этого
    }
}
