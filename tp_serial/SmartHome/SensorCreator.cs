using System.ComponentModel;

namespace SmartHome
{
    public interface ISensorCreator
    {
        public ISensor CreateTempSensor();

        public ISensor CreatePressureSensor();
    }

    
    public class ImperialSensorCreator : ISensorCreator
    {
        public ISensor CreateTempSensor()
        {
            var sensor = new TempSensor();
            TypeDescriptor.AddAttributes(sensor, new MeasureCharacteristic(MeasureUnit.Fahrenheit, MeasureType.Temp));
            return sensor;
        }

        public ISensor CreatePressureSensor()
        {
            var sensor = new PressureSensor();
            TypeDescriptor.AddAttributes(sensor, new MeasureCharacteristic(MeasureUnit.InchOfMercury, MeasureType.Pressure));
            return sensor;
        }
    }

    
    public class InternationalSystemSensorCreator : ISensorCreator
    {
        public ISensor CreateTempSensor()
        {
            var sensor = new TempSensor();
            TypeDescriptor.AddAttributes(sensor, new MeasureCharacteristic(MeasureUnit.Celsius, MeasureType.Temp));
            return sensor;
        }

        public ISensor CreatePressureSensor()
        {
            var sensor = new PressureSensor();
            TypeDescriptor.AddAttributes(sensor, new MeasureCharacteristic(MeasureUnit.Bar, MeasureType.Pressure));
            return sensor;
        }
    }
}