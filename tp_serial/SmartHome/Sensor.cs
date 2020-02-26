using System;

namespace SmartHome
{
    public class Sensor
    {
        public virtual double GetMeasure()
        {
            return (new Random()).Next(100);
        }
    }
}