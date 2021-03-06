﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    abstract class Builder
    {
        public abstract void BuildCartridge();
        public abstract void BuildStrategy();
        public abstract void SetCoordX();
        public abstract void SetCoordY();
        public abstract void SetStartImage();
        public abstract Tank GetResult();
    }
}
