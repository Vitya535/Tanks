using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    abstract class Builder
    {
        public abstract void BuildHealth();
        public abstract void BuildSpeed();
        public abstract void BuildCartridge();
        public abstract void BuildStrategy();
        public abstract void BuildState();
        public abstract Tank GetResult();
    }
}
