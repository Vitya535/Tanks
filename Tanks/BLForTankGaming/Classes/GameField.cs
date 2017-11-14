using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    public class GameField : IGameField
    {
        private static GameField instance;
        // по поводу полей, свойств пока точно не знаю

        protected GameField()
        {

        }

        public static GameField InitializeField()
        {
            if (instance == null)
                instance = new GameField();
            return instance;
        }
    }
}
