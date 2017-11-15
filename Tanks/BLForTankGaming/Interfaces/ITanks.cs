using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface ITanks : IObjectsOnField // интерфейс для танков, не забыть паттерн "Состояние", "Стратегия", "Строитель"
    {
        int GetHealth { get; } // хп танка (будет сотка наверно), поле в классе прилагается
        int GetMoveSpeed { get; } // скорость танка (либо константа (или даже readonly), либо нет - в зависимости от того будут ли влиять какие-то факторы на эту скорость, может быть она вообще не нужна), к нему будет прилагаться соотв. поле
        List<Artifact> Artifacts { get; } // артефакты, которые есть у танка
        IStrategy Strategy { set; } // типа стратегия для танка (если ее можно будет сюда вставить)
        Cartridge TankCartridge { get; } // снаряды, которые есть у танка
    }
}
