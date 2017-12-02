using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface IGame
    {
        List<Tank> TanksInGame { get; } // танки в игре
        List<Obstacles> ObstaclesInGame { get; } // препятствия в игре
        List<Artifact> ArtifactsInGame { get; } // артефакты в игре
        List<CartridgeOnField> CartridgeInGame { get; }
    }
}
