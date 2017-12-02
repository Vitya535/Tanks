using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    abstract class Handler // где Handler будут наследовать клетки поля
    {
        public Handler Successor { get; set; }
        public abstract void TreatmentOfCartridge(int NumberOfCell, int Range);
    }

    // жду Сашу пока он сделает поле
    // class Клетка : Handler
    // {
    //      public override void TreatmentOfCartridge(int NumberOfCell, int Range)
    //      {
    //          if (NumberOfCell == Range)
    //          {
    //              // если на клетке есть танк, то наносим ему урон
    //          }
    //          else if (Successor != null)
    //          {
    //              Successor.TreatmentOfCartridge(++NumberOfCell, Range);
    //              // передаем обработку снаряда следующей клетке
    //          }
    //      }
    // }
}
