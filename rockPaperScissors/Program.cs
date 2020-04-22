using System;
using System.Collections.Generic;

namespace rockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        {   
            //Prompt the user1 to enter name, user1
            Console.WriteLine("Player One, Enter your name!");
            string user1=Console.ReadLine();

            //Prompt the user2 to enter name, user2
            Console.WriteLine("Player Two, Enter your name!");
            string user2=Console.ReadLine();

            //Define user1_wins, user2_wins,user1_choice, user2_choice, total_rounds, ties
            int user1_wins=0;
            int user2_wins=0;
            string user1_choice;
            string user2_choice;
            
            int ties=0;
            // define list result
            List <string> result= new List<string>();
            // define list user1_choices
            List <string> user1_choices= new List <string> ();
            // define list user2_choices
            List <string> user2_choices= new List <string> ();
            //define RPS list
            string [] rps=  {"Rock", "Paper", "Scissors"};
            //create random number generator 
            Random rnd = new Random();
            //create while loop to simulate games
            while( user1_wins <2 && user2_wins <2){
                //Assign random choice to  user1_choice and user2_choice
                user1_choice= rps[rnd.Next(0,3)];
                user2_choice= rps[rnd.Next(0,3)];
                //check if a tie occurs
                if(user1_choice==user2_choice) {
                    //increment tie
                    ties++;
                    //add tie to results
                    result.Add("tie");
                    //add user choices
                    user1_choices.Add(user1_choice);
                    user2_choices.Add(user2_choice);
                
                }
                else if(user1_choice=="Rock" && user2_choice=="Scissors"){
                    //increment user1_wins
                    user1_wins++;
                    // add user1 to result
                    result.Add(user1);
                    //add user choices
                    user1_choices.Add(user1_choice);
                    user2_choices.Add(user2_choice);

                }
                else if(user1_choice=="Scissors" && user2_choice=="Paper"){
                    //increment user1_wins
                    user1_wins++;
                    // add user1 to result
                    result.Add(user1); 
                    //add user choices
                    user1_choices.Add(user1_choice);
                    user2_choices.Add(user2_choice);
                }
                else if(user1_choice=="Paper" && user2_choice=="Rock"){
                    //increment user1_wins
                    user1_wins++;
                    // add user1 to result
                    result.Add(user1);
                    //add user choices
                    user1_choices.Add(user1_choice);
                    user2_choices.Add(user2_choice);
                }
                else{
                   // increment user2_wins
                   user2_wins++;
                   result.Add(user2); 
                   //add user choices
                    user1_choices.Add(user1_choice);
                    user2_choices.Add(user2_choice);
                }
                



            }
            // for loop to print ou the results
            for(int i=0 ;i<result.Count; i++ ){
                //print the result for each round
                if(user1_choices[i]!=user2_choices[i]){
                Console.WriteLine("Round "+(i+1)+" - "+user1+" chooses "+user1_choices[i]+" and "+user2+" chooses "+user2_choices[i]+"- "+result[i]+" wins");
                }
                else{
                    Console.WriteLine("Round "+(i+1)+" - "+user1+" chooses "+user1_choices[i]+" and "+user2+" chooses "+user2_choices[i]+"- The result is a Tie");


                }

            }
            //print if user1 wins
            if(user1_wins== 2){
                Console.WriteLine(user1 +" wins 2-"+user2_wins +" with "+ ties+ " ties.");
            }
            // print if user2 wins
            else{
                Console.WriteLine(user2 +" wins 2-"+user1_wins +" with " +ties+ " ties.");
            }





        }
    }
}
