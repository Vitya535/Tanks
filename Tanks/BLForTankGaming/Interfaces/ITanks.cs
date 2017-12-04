using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface ITanks : IObjectsOnField // интерфейс для танков, не забыть паттерн "Состояние", "Стратегия", "Строитель"
    {
        int Health { get; } // хп танка (будет сотка наверно), поле в классе прилагается
        IStrategy Strategy { set; } // типа стратегия для танка (если ее можно будет сюда вставить)
        Cartridge TankCartridge { get; } // снаряды, которые есть у танка

        void MoveRight();
        void MoveLeft();
        void MoveDown();
        void MoveUp();
        void Shoot();
    }
}
