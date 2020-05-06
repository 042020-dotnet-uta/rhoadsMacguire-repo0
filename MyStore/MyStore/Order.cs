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
    //This class holds the properties of Order
    public class Order
    {
        public int OrderID{ get; set; }

        public int CustId { get; set; }
        

       
        public int Storeid { get; set; }
  

        public int Productid { get; set; }

        private int quantity;

        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        private DateTime orderTime;
        public DateTime OrderTime
        {
            get { return orderTime; }
            set { orderTime = value; }

        }
        private int maxOrder;
        public int MaxOrder
        {
            get { return maxOrder; }
            set { maxOrder = value; }
        }
        public List<Order> Cart { get; set; } = new List<Order>();

        //implements a to String method
        public override string ToString()
        {
            return "Order # " + this.OrderID + ": "+ Quantity+ "x ";
        }


        public Order() { }


       

       



    }
}
