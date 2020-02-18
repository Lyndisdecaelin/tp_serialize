using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

public class MyJSON
{
    private static dynamic iter(dynamic o)
    {
        dynamic res;
        Type type = o.GetType();
        if (type.IsPrimitive || type == typeof(string))
        {
            res = o;
        }
        else if (typeof(IEnumerable).IsAssignableFrom(type))
        {
            var array = new List<dynamic>();
            foreach (var elem in o)
            {
                array.Add(iter(elem));
            }
            res = array;
        }
        else
        {
            res = serialize(o);
        }

        return res;
    }

    public static Dictionary<string, dynamic> serialize(dynamic o)
    {
        Type type = o.GetType();
        var json = new Dictionary<string, dynamic>();
        var prop = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var p in prop)
        {
            json[p.Name] = iter(p.GetValue(o));
        } 
        return json;
    }
}