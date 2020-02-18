using System;

namespace tp_serial
{

    public class toto
    {
        public int i = 42;
        private String name = "mon nom";
    }
    class Program
    {
        static void Main(string[] args)
        {
            toto A = new toto();
            MyJSON.serialize(A);
        }
    }
}
