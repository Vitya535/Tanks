using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    abstract class Builder
    {
        private Random rndOne = new Random();
        private Random rndTwo = new Random();
        public Random GetRndOne { get { return rndOne; } }
        public Random GetRndTwo { get { return rndTwo; } }
        public abstract void BuildCartridge();
        public abstract void BuildStrategy();
        public abstract void SetCoordX();
        public abstract void SetCoordY();
        public abstract void SetStartImage();
        public abstract Tank GetResult();
    }
}
