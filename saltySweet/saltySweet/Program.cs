using System;

namespace saltySweet
{
    class Program
    {
        static void Main(string[] args)
        {
            //Declare variables to keep track of each group fo printout at the end
            int sweet = 0,  sweetSalty = 0,  salty = 0;
            //Loop from 1-100 incrementing by one. i is the loop variable
            for (int i = 1; i <= 100; i++)
            {
                //Declare variables to keep track of divisibiity
                int sweetTest = i % 3, saltyTest = i % 5;
                //Check if Test variables are divisible by 3 and 5
                if (sweetTest == 0 && saltyTest == 0)
                {
                    //if yes, print "sweet'nSalty" and increment the variable tracking it
                    Console.WriteLine("sweet'nSalty");
                    sweetSalty++;

                }
                //Check if Test variables are divisible by 3
                else if (sweetTest == 0)
                {
                    //if yes, print "sweet" and increment the variable tracking it
                    Console.WriteLine("sweet");
                    sweet++;
                }
                //Check if Test variables are divisible by 5
                else if (saltyTest == 0)
                {
                    //if yes, print "salty" and increment the variable tracking it
                    Console.WriteLine("salty");
                    salty++;

                }
                else
                {
                    //if all previous conditions are not met simply print the loop variable, i
                    Console.WriteLine(i);

                }
            }
            //print the results
            Console.WriteLine($"There were {sweet} sweets, {salty} salties, and {sweetSalty} Sweet'nSalties");
        }
    }
}
