using System;

namespace SmartHome
{
    public class VisualizerManager
    {
        /// <summary>
        /// Builds a visualizer by searching in the program for a visualizer that supports the type of data to be displayed.
        /// </summary>
        public IVisualizer BuildVisualizer(MeasureType visualizerType, MeasureUnit visualizerUnit)
        {
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            foreach (var assembly in assemblies)
            {
                var assemblyTypes = assembly.GetTypes();
                foreach (var type in assemblyTypes)
                {
                    if (typeof(IVisualizer).IsAssignableFrom(type) && type.IsDefined(typeof(MeasureCharacteristic), true))
                    {
                        var attr = (MeasureCharacteristic) Attribute.GetCustomAttribute(type, typeof (MeasureCharacteristic));
                        if (attr.type == visualizerType /*&& attr.unit == visualizerUnit*/)
                        {
                            return (IVisualizer) Activator.CreateInstance(type);
                        }
                    }
                }
            }
            return null;
        }
    }
}