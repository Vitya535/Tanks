using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGaming
{
    interface IForGame // интерфейс для игры, не забыть про паттерн "Одиночка", "Хранитель"
    {
        List<Tank> TanksOnField { get; set; } // танки, присутствующие на поле
        List<Obstacles> ObstaclesOnField { get; set; } // препятствия на поле
        List<Artifacts> ArtifactsOnField { get; set; } // артефакты на поле
        List<Cartridge> CartridgesOnField { get; set; } // снаряды на поле
        // возможно должно содержаться еще поле для игры
    }
}
