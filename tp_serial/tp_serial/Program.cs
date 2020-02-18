using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json;

namespace tp_serial
{

    public class titi
    {
        String name = "titiiiiiii";
    }
    public class toto
    {
        public short i = 42;
        public titi B = new titi();

        private List<String> table = new List<String>{"un","deux","trois" };
        
        private String name = "mon nom";

        protected bool yes = true;
    }

    internal class totoInternal : toto
    {
        private int inheritField = 15;
    }
    
    
    public class ComplexObject
    {
        private Object nullA = null;
        private int intA = 4;
        public int intB = 6;
        protected string stringA = "my string";
        private String stringB = "my second string";
        private Func<string, string> myLambda = a => a.ToString();
        
        protected List<toto> listA = new List<toto> {new totoInternal(), new toto(), new toto(), new toto()};
        
        private Dictionary<string, toto> mapA = new Dictionary<string, toto>
        {
            {"a", new toto()},
            {"b", new totoInternal()},
            {"c", null}
        };
        
        private Dictionary<int, dynamic> mapB = new Dictionary<int, dynamic>
        {
            {1, null},  
            {2, "a"},
            {3, new totoInternal()},
            {4, "eeee"},
            {5, 5},
            {6, new String("my string 6")},
            {7, new List<dynamic> {new List<dynamic>
                {
                    "string", 
                    6, 
                    'c', 
                    true, 
                    typeof(ComplexObject), 
                    new object(),
                    
                }}}
        };
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            // toto o = new toto();
            var o = new ComplexObject();
            var json = MyJSON.serialize(o);
            Console.WriteLine("fin");
        }
    }
}
