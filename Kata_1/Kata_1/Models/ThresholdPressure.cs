
using Kata_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_1.Models
{
    public class ThresholdPressure: IThresholdPressure
    {
        public ThresholdPressure(double lower, double upper)
        {
            this.BottomBound = lower;
            this.UpperBound = upper;
        }
    }
}
