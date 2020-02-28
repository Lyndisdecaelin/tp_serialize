using System;

namespace SmartHome
{
    
    public enum MeasureUnit {Celsius, Fahrenheit, Bar, InchOfMercury}
    
    public enum MeasureType {Temp, Pressure}
    
    
    public class MeasureCharacteristic : Attribute
    {
        public MeasureUnit unit;
        public MeasureType type;

        public MeasureCharacteristic(MeasureUnit unit, MeasureType type)
        {
            this.unit = unit;
            this.type = type;
        }
    }
}