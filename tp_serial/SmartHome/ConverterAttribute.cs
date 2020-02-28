using System;

namespace SmartHome
{
    /// <summary>
    /// Meta-data of a converter (input unit, output unit)
    /// </summary>
    public class ConverterAttribute : Attribute
    {
        public MeasureUnit From;
        public MeasureUnit To;

        public ConverterAttribute(MeasureUnit from, MeasureUnit to)
        {
            From = from;
            To = to;
        }
    }
}