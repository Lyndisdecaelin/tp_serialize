using System;

namespace SmartHome
{
    public class Visualizer
    {
        public SensorUnit unit;
        public SensorType type;

        public void Display(double measure)
        {
            Console.WriteLine($"{type.ToString()} : {measure} {unit.ToString()}");
        }
    }
    
    
}