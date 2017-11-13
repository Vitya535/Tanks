using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForGaming
{
    class GameField
    {
        private static GameField instance;
        // по поводу полей, свойств пока точно не знаю

        protected GameField()
        {

        }

        public static GameField Initialize()
        {
            if (instance == null)
                instance = new GameField();
            return instance;
        }
    }
}
