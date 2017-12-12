using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface ITanks : IObjectsOnField // интерфейс для танков, не забыть паттерн "Состояние", "Стратегия", "Строитель"
    {
        IStrategy Strategy { set; } // типа стратегия для танка (если ее можно будет сюда вставить)
        Cartridge TankCartridge { get; } // снаряды, которые есть у танка

        void Move(Tank.Direction r);
        void Shoot();
    }
}
