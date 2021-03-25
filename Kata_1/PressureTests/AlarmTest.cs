
using Kata_1.Interfaces;
using Kata_1.Models;
using Kata_Pressure.TirePressureMonitoringSystem.Tests;
using Xunit;

namespace TDDMicroExercises.TirePressureMonitoringSystem
{
    public class AlarmTest
    {
        private IThresholdPressure Threshold { get; set; }
        private ISensor Sensor { get; }
        private Alarm AlarmToTest { get; }

        public AlarmTest()
        {
            Sensor = new MockSensor();
            Threshold = new ThresholdPressure(100,200);
            Threshold.BottomBound = 0;
            Threshold.UpperBound = 0;

            AlarmToTest = new Alarm(Sensor, Threshold);
        }
        //[Fact]
        //public void Foo()
        //{
        //    Alarm alarm = new Alarm();
        //    Assert.False(alarm.AlarmOn);
        //}

        [Fact]
        public void IsAlarmDesactivated()
        {
            //var alarm = new Alarm(Sensor, Threshold);
            Assert.False(AlarmToTest.AlarmOn);

        }

        [Fact]
        public void IsAlarmTriggered_BecauseBottomBound()
        {
            var sensor = new MockSensor();
            sensor.PushGivenPressure(99);

            // Set the interval so that the alarm will not be triggered
            var thresholds = new ThresholdPressure(100, 600);

            var alarm = new Alarm(sensor, thresholds);

            double currentCounter = alarm.Counter;

            alarm.Check();

            Assert.True(alarm.AlarmOn && currentCounter != alarm.Counter);
        }

        [Fact]
        public void IsAlarmTriggered_BecauseUpperBound()
        {
            var sensor = new MockSensor();
            sensor.PushGivenPressure(601);

            // Set the interval so that the alarm will not be triggered
            var thresholds = new ThresholdPressure(100, 600);

            var alarm = new Alarm(sensor, thresholds);

            double currentCounter = alarm.Counter;

            alarm.Check();

            Assert.True(alarm.AlarmOn && currentCounter != alarm.Counter);
        }

        [Fact]
        public void IsAlarmNotTriggered()
        {
            var sensor = new MockSensor();
            sensor.PushGivenPressure(150);

            // Set the interval so that the alarm will not be triggered
            var thresholds = new ThresholdPressure(100, 600);

            var alarm = new Alarm(sensor, thresholds);

            double currentCounter = alarm.Counter;

            alarm.Check();

            Assert.True(!alarm.AlarmOn && currentCounter == alarm.Counter);
        }

    }
}