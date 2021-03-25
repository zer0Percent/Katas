using Kata_1.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kata_Pressure.TirePressureMonitoringSystem.Tests
{
    public class MockSensor : ISensor
    {
        double CurrentPressure { get; set; }
        Stack<double> Pressures = new Stack<double>();

        
        public void PushGivenPressure(double pressure)
        {
            this.Pressures.Push(pressure);
        }

        public double PopNextPressurePsiValue()
        {
            return this.Pressures.Pop();
        }

    }
}
