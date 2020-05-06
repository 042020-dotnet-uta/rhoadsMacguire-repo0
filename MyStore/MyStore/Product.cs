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
    //Product class which allows for product ordering 
    public class Product  
    {

        public int ProductID { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private int storeID;
        public int StoreID
        {
            get { return storeID; }
            set { storeID = value; }
        }


        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }
        public override string ToString()
       
        {
            return ( "\nName: " + Name +"\nProduct Price: " + Price +"\nLocation ID" + StoreID );
        }

    
       // Product() { }

    }
}
