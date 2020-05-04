using System;
using System.Text.RegularExpressions;
namespace CodingChallengeWeek3
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleKey input;// initialize input to take user input
            var numTest = @"^\d{0,}$";//Regular expression to ensure numbers are entered

            while (true)// This loop keeps you in the menu until you hit E
            {
                //Prints the different methods you can use
                Console.WriteLine("Which Method would you like to run?");
                Console.WriteLine("I: isEven(int)");
                Console.WriteLine("M: MultiTable(int)");
                Console.WriteLine("S: Shuffle(List<object>, List<object>)");
                Console.WriteLine("E: Exit");

                input = Console.ReadKey(false).Key;// takes input from the user
                Console.WriteLine();
                if (input == ConsoleKey.I)//checks input
                {

                    IsEven(numTest);//runs IsEven
                   
                }

                else if (input == ConsoleKey.M)// checks input
                {
                    

                    MultTable(numTest);// runs MultTable
                    
                }
                else if (input == ConsoleKey.S)//checks inut
                {
                    Shuffle();// runs shuffle
                    
                }
                else if (input == ConsoleKey.E)// checks input
                {
                    Console.WriteLine("Goodbye");
                    break;// exits program
                }
                else
                {
                    Console.WriteLine("Invalid input, Please try again");
                    //addresses invalid output

                }
            }



        }
        /*Method prints to the console whether or not 
         * the user's number is even.*/
        static void IsEven(string numTest)
        {
            int temp;
            while (true)
            {
                //prompts user input
                Console.WriteLine("Please enter a number to" +
                    " determine if it is even");
                var x = Console.ReadLine();

                if (Regex.IsMatch(x, numTest))//checks input
                {
                    temp = int.Parse(x);// converts from string to int
                    break;
                }
                else { 
                    Console.WriteLine("Error: Please enter a number"); 
                    //deals with invalid input
                }
            }

            if (temp % 2 == 0)//checks if number is even
            {
                Console.WriteLine($"The Number {temp} is even");
            }
            else
            {
                Console.WriteLine($"The Number {temp} is not even");
            }

        }
        /*This method takes a number inputted from the user and 
         * displays a multiplication table*/
        static void MultTable(string numTest)
        {
            int temp;
            while (true)
            {
                Console.WriteLine("Please enter a number to" +
                    " see it's mutiplicaion table");
                var x = Console.ReadLine();

                if (Regex.IsMatch(x, numTest))// checks if user input is a number
                {
                    temp = int.Parse(x);// converts to int
                    break;
                }
                else 
                { 
                    Console.WriteLine("Error: PLease enter a number");
                    //catches invalid input
                
                }
            }
            //This loop takes the user's number and prints the products with 1-9
            for (int i = 1; i < 10; i++)
            {
                int result = temp * i;
                Console.WriteLine($"{temp} * {i} = {result}");
            }


        }
        /* This method takes two arrays inputted by the user and shuffles their elements
         * so the first element of the new array is the first element of the first orginal 
         * array, the second of the new array is the first of the second orginal array
         * and so on.*/
        static void Shuffle()
        {

                //initialize the arrays we will use
                string[] shuff1 = new string[5];
                string[] shuff2 = new string[5];
                string[] shuffled = new string[10];
                var input = "";
                // This loop prompts the user and adds their responses to the arrays
                for (int i= 0; i<5; i++)
                {
                    Console.WriteLine($"Enter element {i} of the first array");
                    input = Console.ReadLine();
                    shuff1[i] = input;
                    Console.WriteLine($"Enter element {i} of the second array");
                    input = Console.ReadLine();
                    shuff2[i] = input;
                }
                // this loop shuffles the arrays
                for (int i = 0; i <5; i++)
                {
                    shuffled[(i*2)] = shuff1[i];
                    shuffled[(i*2+1)] = shuff2[i];

                }
                //this loop prints the shuffled array
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(shuffled[i]);
            }


            }
        }
    }
