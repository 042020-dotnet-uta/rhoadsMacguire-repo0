using System;

namespace hello
{
    class Program
    {
        static void Main(string[] args)
        {
            
          
            
            int result = addPlusOne(3,4);
            Console.WriteLine("Hello  World!");
            Console.WriteLine(result);
            
        }
        public static int addPlusOne(int a, int b)
        {
            a++;
            int c = a+b;
            return c;

        }}
}
