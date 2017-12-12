using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface IGame
    {
        List<IObjectsOnField> StaticObjectsInGame { get; }
        List<IDamagable> DamagableObjectsInGame { get; }
    }
}
