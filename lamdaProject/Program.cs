using System;

namespace lamdaProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, string> happyString = x => "Happy " + x;
            Console.WriteLine(happyString("cat"));
        }
    }
}
