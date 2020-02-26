using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;


namespace SmartHome
{
    public class SensorsManager
    {
        private Dictionary<Sensor, Visualizer> _sensors;
        private Dictionary<SensorUnit, Type> _converters;

        private VisualizerBuilder _visualizerBuilder;
        public SensorsManager()
        {
            _visualizerBuilder = new VisualizerBuilder();
            _sensors = new Dictionary<Sensor, Visualizer>();
            _converters = new Dictionary<SensorUnit, Type>();
            
            var threadRef = new ThreadStart(Sense);
            var thread = new Thread(threadRef);
            thread.Start();
            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            
            foreach (var assembly in assemblies)
            {
                var assemblyTypes = assembly.GetTypes();

                foreach (var type in assemblyTypes)
                {
                    if (type.IsDefined(typeof(ConverterAttribute), true))
                    {
                        var attr = (ConverterAttribute) Attribute.GetCustomAttribute(type, typeof (ConverterAttribute));
                        _converters[attr.From] = type;
                    }
                }
            }
            Console.WriteLine();
        }
        

        
        public void AddSensor(Sensor sensor)
        {
            var attributes = TypeDescriptor.GetAttributes(sensor);
            
            foreach (var attr in attributes)
            {
                if (attr.GetType() == typeof(SensorAttribute))
                {
                    var sensorAttr = (SensorAttribute) attr;
                    _visualizerBuilder.SetType(sensorAttr.type);
                    _visualizerBuilder.SetUnit(sensorAttr.unit);
                }
            }
            
            // var converter = (Converter) Activator.CreateInstance(type);
            
            var visualizer = _visualizerBuilder.GetResult();
            if (visualizer == null)
                throw new Exception();
            _sensors[sensor] = visualizer;
        }

        public void RemoveSensor(Sensor sensor)
        {
            _sensors.Remove(sensor);
        }

        private void Sense()
        {
            while (true)
            {
                foreach (var s in _sensors)
                {
                    var measure = s.Key.GetMeasure();
                    s.Value.Display(measure);
                }
                Thread.Sleep(500);
            }
        }
    }
}