using System;

namespace SmartHome
{
    class Program
    {
        static void Main(string[] args)
        {
            var sensorManager = new SensorsManager();

            var sensorBuilder = new SensorBuilder();
            sensorBuilder.SetType(SensorType.Temp);
            sensorBuilder.SetUnit(SensorUnit.Celsius);
            var sensor1 = sensorBuilder.GetResult();
            
            sensorBuilder.Reset();
            sensorBuilder.SetType(SensorType.Temp);
            sensorBuilder.SetUnit(SensorUnit.Fahrenheit);
            var sensor2 = sensorBuilder.GetResult();
            
            sensorManager.AddSensor(sensor1);
            sensorManager.AddSensor(sensor2);
        }
    }
}