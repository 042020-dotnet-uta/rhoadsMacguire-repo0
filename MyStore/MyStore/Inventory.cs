using System;
using System.Collections.Generic;
using System.Text;

namespace MyStore
{
   public class Inventory
    {
		private int id;

		public int ID
		{
			get { return id; }
			set { id = value; }
		}

		private StoreLocation location;

		public StoreLocation Location
		{
			get { return location; }
			set { location = value; }
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

		public Inventory() { }
		public bool AddToInventory(Product newProd, int quant)
		{
			return true;
		}
	}
}
