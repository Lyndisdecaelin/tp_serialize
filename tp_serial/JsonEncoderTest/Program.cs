using System;
using System.Collections.Generic;


namespace JsonEncoderTest
{
    public class Titi
    {
        string name = "titiiiiiii";
    }
    
    public class Toto
    {
        public short i = 42;
        public Titi B = new Titi();

        private List<string> table = new List<string>{"un","deux","trois" };
        
        private string name = "mon nom";

        protected bool yes = true;
    }

    internal class TotoInternal : Toto
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
        
        protected List<Toto> listA = new List<Toto> {new TotoInternal(), new Toto(), new Toto(), new Toto()};
        
        private Dictionary<string, Toto> mapA = new Dictionary<string, Toto>
        {
            {"a", new Toto()},
            {"b", new TotoInternal()},
            {"c", null}
        };
        
        private Dictionary<int, dynamic> mapB = new Dictionary<int, dynamic>
        {
            {1, null},  
            {2, "a"},
            {3, new TotoInternal()},
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
            var test = MyJSON.Serialize(o);
            Console.WriteLine();
        }
        
    }
}