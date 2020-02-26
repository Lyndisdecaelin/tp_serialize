using System;

namespace SmartHome
{
    
    public enum SensorUnit {Celsius, Fahrenheit, Liter, Gallon}
    
    public enum SensorType {Temp, Vol}
    
    
    public class SensorAttribute : Attribute
    {
        public SensorUnit unit;
        public SensorType type;

        public SensorAttribute(SensorUnit unit, SensorType type)
        {
            this.unit = unit;
            this.type = type;
        }
    }
}