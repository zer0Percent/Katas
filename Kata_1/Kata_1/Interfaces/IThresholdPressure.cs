using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_1.Interfaces
{
    public abstract class IThresholdPressure
    {
        public double BottomBound { get; set; }
        public double UpperBound { get; set; }

    }
}
