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
    public class Order
    {
        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        private User user;
        public User User
        {
            get { return user; }
            set { user = value; }
        }
        private StoreLocation localStore;
        public StoreLocation LocalStore
        {
            get { return localStore; }
            set { localStore = value; }
        }
        private Product product;
        public Product Product
        {
            get { return product; }
            set { product = value; }

        }
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

        public override string ToString()
        {
            return "Order # " + this.ID + ": "+ Quantity+ "x " + Product.Name;
        }
        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Order testObj)) return false;
            else return Equals(testObj);
        }
        public override int GetHashCode()
        {
            return ID;


        }

        public Order() { }

        public Order(User NewUser, StoreLocation NewStore,Product ChosenProduct, int quantity)
        {
            User = NewUser;
            LocalStore = NewStore;
            Product = ChosenProduct;
            Quantity = quantity;

            


        }
        public bool AddToOrder( int quant = 1)
        {

            if (this.Product == null) return false;
            if (!(this.Product is Product)) return false;
            foreach (Order op in this.Cart)
            {
                if (op.Equals(this.Product))
                {
                    op.Quantity += quant;
                    return true;
                }
            }
            this.Cart.Add(new Order(this.User,this.LocalStore , this.Product, this.Quantity));
            return true;

        }

        public bool DeleteFromOrder(Product prod)
        {
            if (prod == null) return false;
            if (!(prod is Product)) return false;
            foreach (Order ord in this.Cart)
            {
                if (ord.Product.Equals(prod))
                {
                    Cart.Remove(ord);
                    return true;
                }
            }
            Console.WriteLine($"Product {prod.ID} not found. Nothing was deleted from the order.");
            return false;
        }

        public bool UpdateQuantity(Product prod, int newQuant)
        {
            if (!(prod is Product)) return false;
            foreach (Order op in this.Cart)
            {
                if (op.Product.Equals(prod))
                {
                    op.Quantity = newQuant;
                    return true;
                }
            }
            Console.WriteLine($"Product {prod.ID} not found. Quantity not updated, product not in order.");
            return false;
        }

        public void SubmitOrder()
        {
            this.OrderTime = DateTime.Now;

        }
    }
}
