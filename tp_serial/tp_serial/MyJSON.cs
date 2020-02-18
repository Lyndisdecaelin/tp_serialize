using System;
using System.Collections.Generic;

public class MyJSON
{
    public static Dictionary<String, dynamic> serialize(dynamic o)
    {
        Type type = o.GetType();
        Dictionary<String, dynamic> json = new Dictionary<string, dynamic>();
        var prop = type.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        foreach (var p in prop)
        {
            Console.WriteLine(p);
        }
        return null;
    }

}
