using System;
using System.Collections.Generic;
using System.Reflection;

public class MyJSON
{

    public static dynamic iter(FieldInfo p,dynamic o){
        dynamic res;
        if(p.FieldType.IsPrimitive || p.FieldType == typeof(String)){
                res = p.GetValue(o);
            }
            else if(typeof(System.Collections.IEnumerable).IsAssignableFrom(p.FieldType)) {
                res = new List<dynamic>();
                foreach(var elem in p.GetValue(o)){
                    res.add(iter(elem.GetType().GetField(), elem));
                }
            }
            else{
                res = serialize(p.GetValue(o));
            }

        return res;
    }
    public static Dictionary<String, dynamic> serialize(dynamic o)
    {
        Type type = o.GetType();
        Dictionary<String, dynamic> json = new Dictionary<string, dynamic>();
        var prop = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
        foreach (var p in prop)
        {
            json[p.Name] = iter(p,o);
        }
        return json;
    }

}
