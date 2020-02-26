using System.ComponentModel;

namespace SmartHome
{
    public class SensorBuilder
    {
        private Sensor _sensor;
        private SensorType _curType;
        private SensorUnit _curUnit;

        public SensorBuilder()
        {
            Reset();
        }
        
        public void Reset()
        {
            _sensor = new Sensor();
        }

        public Sensor GetResult()
        {
            var res = _sensor;
            var provider = TypeDescriptor.AddAttributes(_sensor, new SensorAttribute(_curUnit, _curType));
            Reset();
            return res;
        }

        public void SetType(SensorType type)
        {
            _curType = type;
        }

        public void SetUnit(SensorUnit unit)
        {
            _curUnit = unit;
        }
    }
}