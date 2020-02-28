using System;

namespace SmartHome
{
    public interface IVisualizer
    {
        public void Update();

        public void SetSensor(ISensor sensor);
    }

    
    [MeasureCharacteristic(MeasureUnit.Celsius, MeasureType.Temp)]
    class TempVisualizer : IVisualizer
    {
        private ISensor _sensor;

        public void Update()
        {
            Console.WriteLine("Temp " +_sensor.GetMeasure() + " °C");
        }

        public void SetSensor(ISensor sensor)
        {
            _sensor = sensor;
        }
    }

    
    [MeasureCharacteristic(MeasureUnit.Bar, MeasureType.Pressure)]
    class PressureVisualizer : IVisualizer
    {
        private ISensor _sensor;
        

        public void Update()
        {
            Console.WriteLine("Pressure " + _sensor.GetMeasure() + " bar");
        }
        
        public void SetSensor(ISensor sensor)
        {
            _sensor = sensor;
        }
    }
}