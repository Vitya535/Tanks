﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLForTankGame
{
    class Director
    {
        Builder builder;
        public Director(Builder builder)
        {
            this.builder = builder;
        }

        public void Construct()
        {
            builder.BuildCartridge();
            builder.BuildStrategy();
            builder.SetCoordX();
            builder.SetCoordY();
            builder.SetStartImage();
        }
    }
}
