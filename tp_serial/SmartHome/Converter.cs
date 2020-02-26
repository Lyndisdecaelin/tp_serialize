namespace SmartHome
{
    public abstract class Converter : Sensor
    {
        protected Sensor input;

        public Converter(Sensor sensor)
        {
            input = sensor;
        }
    }

    [ConverterAttribute(from: SensorUnit.Celsius, to: SensorUnit.Fahrenheit)]
    public class CelsiusToFahrenheit : Converter
    {
        public CelsiusToFahrenheit(Sensor sensor) : base(sensor)
        {
            
        }

        public CelsiusToFahrenheit() : base(null)
        {
            
        }

        public override double GetMeasure()
        {
            // var measure = input.GetMeasure();
            // return measure * (9/5.0) + 32;
            return 0.0;
        }
    }
}