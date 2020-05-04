﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace MyStore
{
   public class OpenStore
    {

        public User newUser = new User();// intializes the new user
        public StoreLocation newStore = new StoreLocation();// intializes new store
        DbStoreContext db = new DbStoreContext();// set up dbcontext

        //List of state abbreviations to verify user input
        string[] stateAbbreviations = {
            "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA",
            "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY",
            "NC", "ND","OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX",
            "UT","VT", "VA", "WA", "WV", "WI", "WY" };
        //list of regex strings to verify user input
        string regNameTest = @"^([a-zA-Z-]{2,30})*$";
        string regEmailTest = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$";
        string regAddressTest = @"^([a-zA-Z0-9 .-]{0,50})*$";
        string regCityTest = @"^([a-zA-Z -]{2,30})*$";
        string regCellTest = @"^\d{10}$";
        string regZipTest = @"^\d{5}$";

        String test;

        /* This method creates a new user and adds them to the database*/
         public User createNewUser()
        {
           

            //Loop conatains the user to ensure they finish their profile
            while (true)
            {
                //prompts user to enter first name
                Console.WriteLine("Hi, welcome to the Store! Please enter your first name?");
                test = Console.ReadLine();
                //checks to make sure input is valid 
                if (Regex.IsMatch(test, regNameTest)) break;
                Console.WriteLine("Invalid input. Please use letters only for this field.");
            }
            //adds first name to user
            newUser.Fname = test;
            while (true)
            {
                //prompts user to enter last name
                Console.WriteLine($"Hi, {newUser.Fname}! Please enter your last name");
                test = Console.ReadLine();
                //checks input
                if (Regex.IsMatch(test, regNameTest)) break;
                Console.WriteLine("Invalid input. Please use letters only for this field.");
            }
            newUser.Lname = test;

            while (true)
            {
                Console.WriteLine("Please enter your address");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regAddressTest)) break;
                Console.WriteLine("Invalid input. Please use alphanumeric characters only.");
            }
            newUser.Address = test;
            

            while (true)
            {
                Console.WriteLine("Please enter your current city");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regCityTest)) break;
                Console.WriteLine("Invalid input. Please use letters only for this field.");
            }
            newUser.City = test;

            while (true)
            {
                Console.WriteLine("Please enter the abbreviation for your current state");
                test = Console.ReadLine();
                if (stateAbbreviations.Contains(test.ToUpper())) break;
                Console.WriteLine("Invalid input. Please enter valid abbreviation.");

            }
            newUser.State = test;

            while (true)
            {
                Console.WriteLine("Please enter your Zip Code ");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regZipTest)) break;
                Console.WriteLine("Invalid input. Please enter 5 numbers.");
            }
            newUser.Zipcode = test;

            while (true)
            {
                Console.WriteLine("Please enter your cell phone number");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regCellTest)) break;
                Console.WriteLine("Invalid input. Please enter a 10-digit number with no dashes.");
            }
          
            newUser.Cell = "(" + test.Substring(0, 3) + ") " + test.Substring(3, 3) + "-" + test.Substring(6, 4);


            while (true)
            {
                Console.WriteLine("Please enter your email address");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regEmailTest)) break;
                Console.WriteLine("Invalid Email address. Please try again.");
            }

            newUser.PrintUserInfo();
            ConsoleKey response;
            do
            {
                Console.WriteLine("Is this information correct?");
                Console.WriteLine("Press Y to confirm");
                Console.WriteLine("Press N to restart the form");
                Console.WriteLine("Press C to cancel");

                response = Console.ReadKey(false).Key;
                if (response == ConsoleKey.Y)
                {
                    Console.WriteLine();
                    db.User.Add(newUser);
                    db.SaveChanges();
                    return newUser;
                }
                if (response == ConsoleKey.N)
                {
                    Console.WriteLine();
                    return this.createNewUser();
                }
                if (response == ConsoleKey.C)
                {
                    break;
                }

            } while (response != ConsoleKey.Y && response != ConsoleKey.N && response != ConsoleKey.C);
            return null;
        }

        public StoreLocation createNewStore()
        {
            Console.WriteLine("Looks like we do not have a store in yor state." +
                "Would you like to open one?");
            ConsoleKey response; 
            while (true)
            {
                Console.WriteLine("Please select Y or N");
                Console.ReadKey();
            }
        }

        /*
        public void testMethod()
        {

            var dbentry = db.User.Where(x => x.FirstName == "Fred").ToList();
            var linqTest = from cust in db.User
                           where cust.FirstName == "Fred"
                           select cust;
            foreach (User obj in dbentry)
            {
                Console.WriteLine("List of things: " + obj.Lname);
            }
            foreach (User obj in linqTest)
            {
                Console.WriteLine("Second List: " + obj.Lname);
            }

        }*/
    }
}