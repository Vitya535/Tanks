using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public interface IArtifactsOnField : IObjectsOnField // скорей всего метод должен быть статическим, интерфейс для артефактов на поле, паттерн "Адаптер" не забыть
    {
        void CauseEffect(Tank tank); // эффект, оказываемый артефактом на танк
    }
}
