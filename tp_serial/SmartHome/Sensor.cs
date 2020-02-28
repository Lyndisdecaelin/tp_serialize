using System;

namespace SmartHome
{
    public interface ISensor
    {
        public double GetMeasure();
    }

    class TempSensor : ISensor
    {
        public double GetMeasure() => new Random().Next(100);
    }

    class PressureSensor : ISensor
    {
        public double GetMeasure() =>  new Random().Next(10);
    }
}