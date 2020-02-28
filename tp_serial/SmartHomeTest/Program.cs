using SmartHome;

namespace SmartHomeTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var sensorManager = new SensorsManager();
            var imperialCreator = new ImperialSensorCreator();
            var siCreator = new InternationalSystemSensorCreator();
        
            sensorManager.AddSensor(imperialCreator.CreatePressureSensor());
            sensorManager.AddSensor(siCreator.CreateTempSensor());
            sensorManager.AddSensor(imperialCreator.CreateTempSensor());
        }
    }
}