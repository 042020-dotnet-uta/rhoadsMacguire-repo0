using System;
using System.Collections.Generic;
using  Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
namespace rockPaperScissors

    
{


    class Game
    {
        //add logging, used ryan shereda's code for help
        private readonly ILogger _logger;
		public Game(ILogger<Game> logger)
		{
			_logger = logger;
		}

        public Player p1 = new Player();
        public Player p2 = new Player();
        public int ties = 0;
    

        public void runGame()
        {
           // Player p1 = new Player();
            //Player p2 = new Player();

            Log = new LoggerConfiguration()
            .WriteTo.File("consoleapp.log")
            .CreateLogger();


            Log.Information("Hello, world! Let the Game begin!");
            //Prompt the user1 to enter name, user1
            Console.WriteLine("Player One, Enter your name!");
            p1.name = Console.ReadLine();

            //Prompt the user2 to enter name, user2
            Console.WriteLine("Player Two, Enter your name!");
            p2.name = Console.ReadLine();

           




            // define list result
            List<string> result = new List<string>();


            //define RPS list
            string[] rps = { "Rock", "Paper", "Scissors" };
            //create random number generator 
            Random rnd = new Random();
            //create while loop to simulate games
            while (p1.wins < 2 && p2.wins < 2)
            {
                //Assign random choice to  user1_choice and user2_choice
                p1.choice = rps[rnd.Next(0, 3)];
                p2.choice = rps[rnd.Next(0, 3)];
                //check if a tie occurs
                if (p1.choice == p2.choice)
                {
                    //increment tie
                    ties++;
                    //add tie to results
                    result.Add("tie");
                    //add user choices
                    p1.choices.Add(p1.choice);
                    p2.choices.Add(p2.choice);

                }
                else if (p1.choice == "Rock" && p2.choice == "Scissors")
                {
                    //increment user1_wins
                    p1.wins++;
                    // add user1 to result
                    result.Add(p1.name);
                    //add user choices
                    p1.choices.Add(p1.choice);
                    p2.choices.Add(p2.choice);

                }
                else if (p1.choice == "Scissors" && p2.choice == "Paper")
                {
                    //increment user1_wins
                    p1.wins++;
                    // add user1 to result
                    result.Add(p1.name);
                    //add user choices
                    p1.choices.Add(p1.choice);
                    p2.choices.Add(p2.choice);
                }
                else if (p1.choice == "Paper" && p2.choice == "Rock")
                {
                    //increment user1_wins
                    p1.wins++;
                    // add user1 to result
                    result.Add(p1.name);
                    //add user choices
                    p1.choices.Add(p1.choice);
                    p2.choices.Add(p2.choice);
                }
                else
                {
                    // increment user2_wins
                    p2.wins++;
                    result.Add(p2.name);
                    //add user choices
                    p1.choices.Add(p1.choice);
                    p2.choices.Add(p2.choice);
                }




            }
            // for loop to print ou the results
            for (int i = 0; i < result.Count; i++)
            {
                //print the result for each round
                if (p1.choices[i] != p2.choices[i])
                {
                    Console.WriteLine("Round " + (i + 1) + " - " + p1.name + " chooses " + p1.choices[i] + " and " + p2.name + " chooses " + p2.choices[i] + "- " + result[i] + " wins");
                }
                else
                {
                    Console.WriteLine("Round " + (i + 1) + " - " + p1.name + " chooses " + p1.choices[i] + " and " + p2.name + " chooses " + p2.choices[i] + "- The result is a Tie");


                }

            }
            //print if user1 wins
            if (p1.wins == 2)
            {
                Console.WriteLine(p1.name + " wins 2-" + p2.wins + " with " + ties + " ties.");
            }
            // print if user2 wins
            else
            {
                Console.WriteLine(p2.name + " wins 2-" + p1.wins + " with " + ties + " ties.");
            }

        }








    }
}