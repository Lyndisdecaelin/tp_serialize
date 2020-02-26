using System;

namespace SmartHome
{
    public class ConverterAttribute : Attribute
    {
        public SensorUnit From;
        public SensorUnit To;

        public ConverterAttribute(SensorUnit from, SensorUnit to)
        {
            From = from;
            To = to;
        }
    }
}