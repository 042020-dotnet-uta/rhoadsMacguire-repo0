using System;
using System.Collections.Generic;
using  Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging.Console;
namespace rockPaperScissors

    
{


    class Game
    {
        public Game(){}
        
        //add logging, used ryan shereda's code for help
        private readonly ILogger _logger;
        
        public Game(ILogger<Game> logger)
        {
            _logger = logger;
        }
        

        public Player p1 = new Player();
        public Player p2 = new Player();
        public int GameID { get; set; }
        public int ties = 0;
        

        public void runGame()
        {
           // Player p1 = new Player();
            //Player p2 = new Player();

           // Log = new LoggerConfiguration()
            //.WriteTo.File("consoleapp.log")
            //.CreateLogger();


            _logger.LogCritical("Hello");
            //Prompt the user1 to enter Name, user1
            Console.WriteLine("Player One, Enter your Name!");
            p1.Name = Console.ReadLine();

            //Prompt the user2 to enter Name, user2
            Console.WriteLine("Player Two, Enter your Name!");
            p2.Name = Console.ReadLine();

           




            // define list result
            List<string> result = new List<string>();


            //define RPS list
            string[] rps = { "Rock", "Paper", "Scissors" };
            //create random number generator 
            Random rnd = new Random();
            //create while loop to simulate games
            while (p1.wins < 2 && p2.wins < 2)
            {
                //Assign random Choice to  user1_Choice and user2_Choice
                p1.Choice = rps[rnd.Next(0, 3)];
                p2.Choice = rps[rnd.Next(0, 3)];
                //check if a tie occurs
                if (p1.Choice == p2.Choice)
                {
                    //increment tie
                    ties++;
                    //add tie to results
                    result.Add("tie");
                    //add user choices
                    p1.choices.Add(p1.Choice);
                    p2.choices.Add(p2.Choice);

                }
                else if (p1.Choice == "Rock" && p2.Choice == "Scissors")
                {
                    //increment user1_wins
                    p1.wins++;
                    // add user1 to result
                    result.Add(p1.Name);
                    //add user choices
                    p1.choices.Add(p1.Choice);
                    p2.choices.Add(p2.Choice);

                }
                else if (p1.Choice == "Scissors" && p2.Choice == "Paper")
                {
                    //increment user1_wins
                    p1.wins++;
                    // add user1 to result
                    result.Add(p1.Name);
                    //add user choices
                    p1.choices.Add(p1.Choice);
                    p2.choices.Add(p2.Choice);
                }
                else if (p1.Choice == "Paper" && p2.Choice == "Rock")
                {
                    //increment user1_wins
                    p1.wins++;
                    // add user1 to result
                    result.Add(p1.Name);
                    //add user choices
                    p1.choices.Add(p1.Choice);
                    p2.choices.Add(p2.Choice);
                }
                else
                {
                    // increment user2_wins
                    p2.wins++;
                    result.Add(p2.Name);
                    //add user choices
                    p1.choices.Add(p1.Choice);
                    p2.choices.Add(p2.Choice);
                }




            }
            // for loop to print ou the results
            for (int i = 0; i < result.Count; i++)
            {
                //print the result for each round
                if (p1.choices[i] != p2.choices[i])
                {
                    Console.WriteLine("Round " + (i + 1) + " - " + p1.Name + " chooses " + p1.choices[i] + " and " + p2.Name + " chooses " + p2.choices[i] + "- " + result[i] + " wins");
                }
                else
                {
                    Console.WriteLine("Round " + (i + 1) + " - " + p1.Name + " chooses " + p1.choices[i] + " and " + p2.Name + " chooses " + p2.choices[i] + "- The result is a Tie");


                }

            }
            //print if user1 wins
            if (p1.wins == 2)
            {
                Console.WriteLine(p1.Name + " wins 2-" + p2.wins + " with " + ties + " ties.");
            }
            // print if user2 wins
            else
            {
                Console.WriteLine(p2.Name + " wins 2-" + p1.wins + " with " + ties + " ties.");
            }

        }








    }
}