using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForInterfaces
{
    public interface ICartridges // интерфейс, описывающий снаряды, не забыть паттерн "Цепочка обязанностей"
    {
        int GetDamage { get; } // урон снаряда
        int GetRange { get; } // дальность измеряется в клетках (или в иксах и игреках)
        // должен быть еще тип снаряда в виде enum, но он будет в классе
    }
}
