using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;


namespace JsonEncoder
{
    public static class MyJSON
    {
        private static dynamic Iter(dynamic o, string name, int level)
        {
            dynamic res;
            Type type = o?.GetType();
            if (o is null ||  type.IsPrimitive || type == typeof(string))
            {
                res = o;
                Console.WriteLine(new string(' ', level*2) + name + " : " + (o??"null"));
            }
            else if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                var array = new List<dynamic>();
                Console.WriteLine(new string(' ', level*4) + name + " : ");
                foreach (var elem in o)
                {
                    array.Add(Iter(elem, null, level));
                }
                res = array;
            }
            else
            {
                Console.WriteLine(new string(' ', level*4) + name + " : ");
                res = Serialize(o, ++level);
            }
            return res;
        }


        
        public static Dictionary<string, dynamic> Serialize(dynamic o, int level = 0)
        {
            Type type = o.GetType();
            var json = new Dictionary<string, dynamic>();
            var prop = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            foreach (var p in prop)
            {
                json[p.Name] = Iter(p.GetValue(o), p.Name, level);
            }
            return json;
        }
    }
}