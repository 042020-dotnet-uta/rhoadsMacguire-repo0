using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyStore
{
    //This class populates the user object
    public class Cust
    {

        public int CustId { get; set; }

        private string fname;
        public string Fname
        {
            get { return fname; }
            set { fname = value; }

        }
        private string lname;
        public string Lname
        {
            get { return lname; }
            set { lname = value; }

        }
        private string email;
        public string Email
        {
            get { return email; }
            set { email = value; }

        }
        private string cell;

        public string Cell
        {
            get { return cell; }
            set { cell = value; }
        }

        private string address;
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string city;

        public string City
        {
            get { return city; }
            set { city = value; }
        }
        private string state;

        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private string zipCode;

        public string Zipcode
        {
            get { return zipCode; }
            set { zipCode = value; }
        }





        public Cust() { }

        public void PrintUserInfo()
        {
            string[] titles = { "First name", "Last Name", "Address", "City", "State", "Zip Code", "Cell", "Email" };
            string[] data = { Fname, Lname, Address, City, State, Zipcode, Cell, Email };
            Console.WriteLine("---------------------------");
            Console.WriteLine($"UserID {CustId}");
            for (int i = 0; i < titles.Length-1; i++)
            {
                Console.WriteLine("{0,-20} {1,-20}", titles[i], data[i]);
            }
            Console.WriteLine("---------------------------");
        }



    }
}

