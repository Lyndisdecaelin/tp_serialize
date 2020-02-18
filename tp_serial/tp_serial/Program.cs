using System;
using System.Collections.Generic;

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

        private bool yes = true;
    }
    class Program
    {
        static void Main(string[] args)
        {
            toto A = new toto();
            var json = MyJSON.serialize(A);
            Console.WriteLine("fin");
        }
    }
}
