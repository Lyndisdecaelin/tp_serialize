using System;

namespace SmartHome
{
    /// <summary>
    /// Wrap an ISensor to convert its unit into a new unit
    /// </summary>
    public abstract class Converter : ISensor
    {
        protected ISensor convertedSensor;
    
        public Converter(ISensor sensor)
        {
            convertedSensor = sensor;
        }

        public abstract double GetMeasure();
    }
    
    
    [ConverterAttribute(from: MeasureUnit.Fahrenheit, to: MeasureUnit.Celsius)]
    public class CelsiusToFahrenheit : Converter
    {
        public CelsiusToFahrenheit(ISensor sensor) : base(sensor) { }

        public override double GetMeasure()
        {
            var measure = convertedSensor.GetMeasure();
            return measure * (9/5.0) + 32;
        }
    }

    [ConverterAttribute(from: MeasureUnit.Celsius, to: MeasureUnit.Fahrenheit)]
    public class FahrenheitToCelsius : Converter
    {
        public FahrenheitToCelsius(ISensor sensor) : base(sensor) { }

        public override double GetMeasure()
        {
            var measure = convertedSensor.GetMeasure();
            return (measure -32 ) * (5.0/9.0);
        }
    }


    [ConverterAttribute(from: MeasureUnit.InchOfMercury, to: MeasureUnit.Bar)]
    public class InchOfMercuryToBar : Converter
    {
        public InchOfMercuryToBar(ISensor sensor) : base(sensor) { }

        public override double GetMeasure()
        {
            var measure = convertedSensor.GetMeasure();
            return measure / 29.53;
        }
    }

    [ConverterAttribute(from: MeasureUnit.Bar, to: MeasureUnit.InchOfMercury)]
    public class BarToInchOfMercury : Converter
    {
        public BarToInchOfMercury(ISensor sensor) : base(sensor) { }

        public override double GetMeasure()
        {
            var measure = convertedSensor.GetMeasure();
            return measure * 29.53;
        }
    }
}