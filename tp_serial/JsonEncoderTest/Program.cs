using System;
using System.Collections.Generic;
using JsonEncoder;


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
        protected string stringA = "my string";
        
        protected List<Toto> listA = new List<Toto> {new TotoInternal(), new Toto()};

        private Dictionary<int, dynamic> mapB = new Dictionary<int, dynamic>
        {
            {1, null},  
            {2, "a"},
            {3, new TotoInternal()},
            {7, new List<dynamic> {new List<dynamic>
                {
                    "string", 
                    6, 
                    'c', 
                    true,
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