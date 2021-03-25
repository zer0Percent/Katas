using Kata_1.Interfaces;


namespace Kata_1.Models
{
    public class Alarm
    {
        //private const double LowPressureThreshold = 17;
        //private const double HighPressureThreshold = 21;

        //Sensor _sensor = new Sensor();

        //bool _alarmOn = false;
        public long Counter = 0;

        public ISensor sensor { get; set; }
        public IThresholdPressure Threshold { get; set; }

        public bool AlarmOn { get; set; }
        public Alarm(ISensor sensor, IThresholdPressure threshold)
        {
            this.sensor = sensor;
            this.Threshold = threshold;
        }

        public void Check()
        {
            double psiPressureValue = sensor.PopNextPressurePsiValue();
            
            if (psiPressureValue < Threshold.BottomBound || Threshold.UpperBound < psiPressureValue)
            {
                AlarmOn = true;
                Counter += 1;
            }
        }

        //public bool AlarmOn
        //{
        //    get { return _alarmOn; }
        //}
    }
}
