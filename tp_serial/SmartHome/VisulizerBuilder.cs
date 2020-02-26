namespace SmartHome
{
    public class VisualizerBuilder
    {
        private Visualizer _visualizer;

        public VisualizerBuilder()
        {
            Reset();
        }
        
        public void Reset()
        {
            _visualizer = new Visualizer();
        }

        public Visualizer GetResult()
        {
            var res = _visualizer;
            Reset();
            return res;
        }

        public void SetType(SensorType type)
        {
            _visualizer.type = type;
        }

        public void SetUnit(SensorUnit unit)
        {
            _visualizer.unit = unit;
        }
    }
}