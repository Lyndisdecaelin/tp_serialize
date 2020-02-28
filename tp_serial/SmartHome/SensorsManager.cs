using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;


namespace SmartHome
{
    /// <summary>
    /// Add, remove and update sensors
    ///
    /// Automatically create visualizer for the added sensor, and if necessary a converter too
    /// </summary>
    public class SensorsManager
    {
        // Sensors with their visualizers
        private Dictionary<ISensor, IVisualizer> _sensors;
        
        // Converters supported by the program (types)
        private Dictionary<MeasureUnit, Type> _converters;
        
        private VisualizerManager _visualizerManager;
        
        
        public SensorsManager()
        {
            _sensors = new Dictionary<ISensor, IVisualizer>();
            _converters = new Dictionary<MeasureUnit, Type>();
            _visualizerManager = new VisualizerManager();
            RetrieveAllConverters();
            new Thread(Sense).Start();
        }
        
        
        /// <summary>
        /// 1. Read sensor metadata (unit, type)
        /// 2. Create a visualizer for this sensor
        /// 3. If the type of the visualizer is not the same as the sensor type, a converter is used to wrap the sensor
        /// </summary>
        public void AddSensor(ISensor sensor)
        {
            var measureCharacteristic = GetSensorCharacteristic(sensor);
            var visualizer = _visualizerManager.BuildVisualizer(measureCharacteristic.type, measureCharacteristic.unit);
            sensor = WrapSensorIfNecessary(sensor, visualizer);
            
            visualizer.SetSensor(sensor);
            _sensors[sensor] = visualizer;
        }


        public void RemoveSensor(ISensor sensor)
        {
            _sensors.Remove(sensor);
        }

        
        private MeasureCharacteristic GetSensorCharacteristic(ISensor sensor)
        {
            var attributes = TypeDescriptor.GetAttributes(sensor);
            MeasureCharacteristic measureCharacteristic = null;
            foreach (var attr in attributes)
            {
                if (attr.GetType() == typeof(MeasureCharacteristic))
                {
                    measureCharacteristic = (MeasureCharacteristic) attr;
                    break;
                }
            }
            return measureCharacteristic;
        }
        

        private ISensor WrapSensorIfNecessary(ISensor sensor, IVisualizer visualizer)
        {
            var sensorCharacteristic = GetSensorCharacteristic(sensor);
            var visualizerAttribute = (MeasureCharacteristic) Attribute.GetCustomAttribute(visualizer.GetType(), typeof (MeasureCharacteristic));
            if (visualizerAttribute.unit != sensorCharacteristic.unit)
            {
                var converter = _converters[sensorCharacteristic.unit];
                sensor = (Converter) Activator.CreateInstance(converter, sensor);
                Console.WriteLine($"Apply converter : {converter}");
            }
            return sensor;
        }
        
        
        private void RetrieveAllConverters()
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var assemblyTypes = assembly.GetTypes();

                foreach (var type in assemblyTypes)
                {
                    if (typeof(Converter).IsAssignableFrom(type) && type.IsDefined(typeof(ConverterAttribute), true))
                    {
                        var attr = (ConverterAttribute) Attribute.GetCustomAttribute(type, typeof (ConverterAttribute));
                        _converters[attr.From] = type;
                    }
                }
            }
        }
        
        
        private void Sense()
        {
            while (true)
            {
                foreach (var s in _sensors)
                    s.Value.Update();
                Thread.Sleep(500);
            }
        }
    }
}