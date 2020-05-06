using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;

namespace MyStore
{
    //This class contains the functionality 
    public class OpenStore
    {
        Product newProduct = new Product();
        public Cust newUser = new Cust();// intializes the new user
        public StoreLocation newStore = new StoreLocation();// intializes new store
       
        
        // List of state abbreviations to verify user input
        string[] stateAbbreviations = {
            "AL", "AK", "AZ", "AR", "CA", "CO", "CT", "DE", "DC", "FL", "GA",
            "HI", "ID", "IL", "IN", "IA", "KS", "KY", "LA", "ME", "MD", "MA",
            "MI", "MN", "MS", "MO", "MT", "NE", "NV", "NH", "NJ", "NM", "NY",
            "NC", "ND","OH", "OK", "OR", "PA", "RI", "SC", "SD", "TN", "TX",
            "UT","VT", "VA", "WA", "WV", "WI", "WY" };
        // list of regex strings to verify user input
        string regNameTest = @"^([a-zA-Z-]{2,30})*$";
        string regEmailTest = @"^([a-zA-Z0-9._%-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})*$";
        string regAddressTest = @"^([a-zA-Z0-9 .-]{0,50})*$";
        string regCityTest = @"^([a-zA-Z -]{2,30})*$";
        string regCellTest = @"^\d{10}$";
        string regZipTest = @"^\d{5}$";
        string regProductTest = @"^([a-zA-Z .-]{0,50})*$";
        string regPriceTest = @"^\d{0,4}(\.\d{2})?$";
        string idTest = @"^\d{1}";
        //Input validation burrows from Ryan Oxford's code
        String test = "";

        public void runStore()
        {
            DbStoreContext db = new DbStoreContext();// set up dbcontext
            bool broken = true;// bool to get us out of loop
            ConsoleKey input;// intial console key

            //Menu options
            string[] menu = new string[] { "Create new order", "Create new user",
                        "Search User by name", "Look up your Order history", "Update inventory",
                        "Create new product", "Look up location order history", "Exit Program" };
            Console.WriteLine("Welcome to the Outdoor Store");
            
            do
            {
                //loop through menu options
                for (int i = 0; i < menu.Length; i++)
                {
                    int num = i + 1;
                    Console.WriteLine(num + " " + menu[i]);
                }
                input = Console.ReadKey().Key;

                //Create Order
                if (input == ConsoleKey.D1)
                {   //initialize order
                    Order newOrder = createOrder();
                    //check that it is not null
                    if (newOrder == null)
                    {

                        Console.WriteLine();
                        Console.WriteLine($"Order cancelled.");
                    }

                    else if (newOrder != null)
                    {// Add new Order to the db
                        newOrder.OrderTime = DateTime.Now;
                        db.Add(newOrder);

                        db.SaveChanges();
                        Console.WriteLine();
                        Console.WriteLine($"Order added as order {newOrder.OrderID}");
                    }

                }





                //Create user
                else if (input == ConsoleKey.D2)
                {

                    newUser = createNewUser();
                    Console.WriteLine("Her is you User ID: " + newUser.CustId);
                }
                //User search
                else if (input == ConsoleKey.D3)
                {

                    List<Cust> searchResults = findUser();
                    if (searchResults.Count >= 1)
                    {
                        foreach (Cust p in searchResults)
                        {
                            //Print results
                            p.PrintUserInfo();
                        }
                    }
                    else
                    {
                        Console.WriteLine("Loooks like nothing came up." +
                            " Try to create a new user!");
                        Console.WriteLine();
                    }
                }
                //Location search
                else if (input == ConsoleKey.D4)
                {

                    List<Order> searchResults = findUserOrderHistory();


                    if (searchResults.Count >= 1)
                    {
                        //loop through to include product name
                        for (int i = 0; i < searchResults.Count; i++)
                        {
                            List<Product> hold = db.Product.Where(prod => prod.ProductID == searchResults[i].Productid).ToList();
                            Console.WriteLine(searchResults[i].ToString() + hold[i].Name);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Loooks like nothing came up." +
                            " Try to create a new Order!");
                        Console.WriteLine();
                    }
                }
                //Adjust inventory
                else if (input == ConsoleKey.D5)
                {
                    adjustInventory();
                    //Update inventory
                }
                //create new Product
                else if (input == ConsoleKey.D6)
                {
                    createProduct();

                }
                //StoreLocation order history
                else if (input == ConsoleKey.D7)
                {

                    List<Order> searchResults = findLocalOrderHistory();


                    if (searchResults.Count >= 1)
                    {
                        //loops through to print out product names
                        for (int i = 0; i < searchResults.Count; i++)
                        {
                            List<Product> hold = db.Product.Where(prod => prod.ProductID == searchResults[i].Productid).ToList();
                            Console.WriteLine(searchResults[i].ToString() + hold[i].Name);
                        }

                    }
                    else
                    {
                        Console.WriteLine("Loooks like nothing came up." +
                            " Try to create a new order!");
                        Console.WriteLine();
                    }
                }

                //exit the loop

                else if (input == ConsoleKey.D8)
                {
                    broken = false;
                    Console.WriteLine();
                    Console.WriteLine(broken);
                }


                else
                {
                    Console.WriteLine(broken);
                    Console.WriteLine("Whoops. Please press a valid key");
                }
            } while (broken==true);
        }
        


        /* This method creates a new user and adds them to the database*/
        public Cust createNewUser()
        {
            DbStoreContext db = new DbStoreContext();// set up dbcontext

            //previous check to see if db was working
            //var user1 = db.Cust.FirstOrDefault();
            //Console.WriteLine($"The user is {user1.CustId},{user1.Fname},{user1.Lname},{user1.State}");


            // Loop contains the user to ensure they finish their profile
            while (true)
            {
                //  prompts user to enter first name
                Console.WriteLine("Hi! Please enter your first name?");
                test = Console.ReadLine();
                // checks to make sure input is valid
                if (Regex.IsMatch(test, regNameTest)) break;
                Console.WriteLine("Invalid input. Please use letters only for this field.");
            }
            //adds first name to user
            newUser.Fname = test;
            while (true)
            {
                //  prompts user to enter last name
                Console.WriteLine($"Hi, {newUser.Fname}! Please enter your last name");
                test = Console.ReadLine();
                //checks input
                if (Regex.IsMatch(test, regNameTest)) break;
                Console.WriteLine("Invalid input. Please use letters only for this field.");
            }
            //adds last name
            newUser.Lname = test;

            while (true)
            {
                //checks input
                Console.WriteLine("Please enter your address");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regAddressTest)) break;
                Console.WriteLine("Invalid input. Please use alphanumeric characters only.");
            }
            //adds address
            newUser.Address = test;


            while (true)
            {
                //checks input
                Console.WriteLine("Please enter your current city");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regCityTest)) break;
                Console.WriteLine("Invalid input. Please use letters only for this field.");
            }
            //adds city
            newUser.City = test;

            while (true)
            {
                //checks input
                Console.WriteLine("Please enter the abbreviation for your current state");
                test = Console.ReadLine();
                if (stateAbbreviations.Contains(test.ToUpper())) break;
                Console.WriteLine("Invalid input. Please enter valid abbreviation.");

            }
            //adds state
            newUser.State = test;

            while (true)
            {
                //checks input
                Console.WriteLine("Please enter your Zip Code ");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regZipTest)) break;
                Console.WriteLine("Invalid input. Please enter 5 numbers.");
            }
            //adds zipcode
            newUser.Zipcode = test;

            while (true)
            {
                //checks input
                Console.WriteLine("Please enter your cell phone number");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regCellTest)) break;
                Console.WriteLine("Invalid input. Please enter a 10-digit number with no dashes.");
            }
            //adds cellphone
            newUser.Cell = "(" + test.Substring(0, 3) + ") " + test.Substring(3, 3) + "-" + test.Substring(6, 4);


            while (true)
            {
                //checks input
                Console.WriteLine("Please enter your email address");
                test = Console.ReadLine();
                if (Regex.IsMatch(test, regEmailTest)) break;
                Console.WriteLine("Invalid Email address. Please try again.");
                
            }
            //adds email
            newUser.Email = test;
            //print info
            newUser.PrintUserInfo();
            ConsoleKey response;
            //confirm info with user
            do
            {
                Console.WriteLine("Is this information correct?");
                Console.WriteLine("Press Y to confirm");
                Console.WriteLine("Press N to restart the form");
                Console.WriteLine("Press C to cancel");

                response = Console.ReadKey(false).Key;
                if (response == ConsoleKey.Y)
                {// adds to db
                    Console.WriteLine();
                    db.Add(newUser);
                    db.SaveChanges();
                    return newUser;
                }
                if (response == ConsoleKey.N)
                {//returs to start
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
    





public Product createProduct()
{
    DbStoreContext db = new DbStoreContext();// set up dbcontext
    ConsoleKey response;
    var test = "";
    while (true)
    {
        Console.WriteLine("What would you like to call the new Product?");
        test = Console.ReadLine();

        //checks input
        if (Regex.IsMatch(test, regProductTest))
        {//add product name
            newProduct.Name = test;
            Console.WriteLine("How much should it cost?");
            test = Console.ReadLine();
            //checks input
            if (Regex.IsMatch(test, regPriceTest))
            {// adds price
                newProduct.Price = double.Parse(test);
                Console.WriteLine("Where should we stock the product?" +
                    " Enter a store ID please");
                        var dbstores = db.StoreLocation.ToArray();
                        foreach (var store in dbstores)
                        {
                            //print store options
                            Console.WriteLine($"{store.StoreLocationID}: {store.City}");
                        }


                        



                        //user chooses a location
                        while (true)
                        {
                            response = Console.ReadKey().Key;
                            if (response == ConsoleKey.D1)
                            {
                                newProduct.StoreID = 1;
                                break;
                            }
                            else if (response == ConsoleKey.D2)
                            {
                                newProduct.StoreID = 2;
                                break;

                            }
                            else if (response == ConsoleKey.D3)
                            {
                                newProduct.StoreID = 3;
                                break;

                            }
                            else
                            {
                                Console.WriteLine("invalid, please enter a know store id");
                            }
                        }

                        //get a quantity for the product
                        while (true)
                        {
                            Console.WriteLine("How many should we stock?");
                            test = Console.ReadLine();
                            if ( int.Parse(test)>0)
                            {
                                newProduct.Quantity = int.Parse(test);
                                Console.WriteLine(newProduct.ToString());
                                break;








                            }
                            else
                            {
                                Console.WriteLine("invalid input");

                            }
                        }
                    while (true)
                    {
                            //confirm product info
                        Console.WriteLine("Is this information correct?");
                        Console.WriteLine("Press Y to confirm");
                        Console.WriteLine("Press N to restart the form");
                        Console.WriteLine("Press C to cancel");

                        response = Console.ReadKey(false).Key;
                        if (response == ConsoleKey.Y)
                        {
                                //save to db
                            Console.WriteLine();
                            db.Add(newProduct);
                            db.SaveChanges();
                            return newProduct;
                        }
                        if (response == ConsoleKey.N)
                        {
                            Console.WriteLine();
                            return this.createProduct();
                        }
                        if (response == ConsoleKey.C)
                        {
                            break;
                        }
                        newStore.Products.Add(newProduct);

                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please use numbers only");

                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please use letters only");

            }

        }





    }








public List<Cust> findUser()
{
    DbStoreContext db = new DbStoreContext();// set up dbcontext
    Cust findUser = new Cust();
    while (true)
    {
        //prompts user to enter first name
        Console.WriteLine("Enter your first name");
        test = Console.ReadLine();
        //checks to make sure input is valid 
        if (Regex.IsMatch(test, regNameTest)) break;
        Console.WriteLine("Invalid input. Please use letters only for this field.");
    }
    //adds first name to user
    findUser.Fname = test;
    while (true)
    {
        //prompts user to enter last name
        Console.WriteLine($"Hi, {newUser.Fname}! Please enter your last name");
        test = Console.ReadLine();
        //checks input
        if (Regex.IsMatch(test, regNameTest)) break;
        Console.WriteLine("Invalid input. Please use letters only for this field.");
    }
    //adds Last name
    findUser.Lname = test;
    var searchResults = db.Cust.Where(cust => cust.Fname == findUser.Fname && cust.Lname == findUser.Lname).ToList();
    return searchResults;
}


public Order createOrder()
{
    DbStoreContext db = new DbStoreContext();// set up dbcontext

    Order newOrder = new Order();
    ConsoleKey temp;
    var input = "";
    //order creation loop
    while (true)

    {
        Console.WriteLine("What is your customer id?");
        input = Console.ReadLine();
        //checks input
        if (Regex.IsMatch(input,idTest)){
                    //pull out customer info
                    int id = int.Parse(input);
                    var dbid= db.Cust.Where(cust => cust.CustId == id).ToList();
                    if (dbid.Count>0)
            {
                        Console.WriteLine("What Location would you like " +
                            "to order from");
                        newOrder.CustId = id;
                        //cycle through storelocations
                        var dbstores = db.StoreLocation.ToArray();
                        foreach (var store in dbstores)
                        {
                            Console.WriteLine($"{store.StoreLocationID}: {store.City}");
                        }


                        
                        //user chooses location
                        while (true)
                        {
                            temp = Console.ReadKey().Key;
                            if (temp == ConsoleKey.D1)
                            {
                                newOrder.Storeid = 1;
                                break;
                            }
                            else if (temp == ConsoleKey.D2)
                            {
                                newOrder.Storeid = 2;
                                break;

                            }
                            else if (temp == ConsoleKey.D3)
                            {
                                newOrder.Storeid = 3;
                                break;

                            }
                            else
                            {
                                Console.WriteLine("invalid, please enter a known store id");
                            }
                        }
                        //query and print a list of products
                var dbinventory = db.Product.Where(prod => prod.StoreID == newOrder.Storeid);

                Console.WriteLine("Here is a list of Products");
                
                List <string> inv = new List<string>();
                        //print products
                foreach( Product p in dbinventory)
                            {
                    Console.WriteLine(p.Name);
                            //get list of strings for comparison
                            inv.Add(p.Name);

                            }
                
                while (true)
                {
                    Console.WriteLine("Type the name of your desired product");
                    input = Console.ReadLine();
                    if (inv.Contains(input))
                    {
                                // "load product into variable" 
                        List <Product> dbGet = db.Product.Where(prod => prod.Name == input).ToList();
                        Console.WriteLine("How many?");

                        input = Console.ReadLine();

                            //put product into the order    
                        newOrder.Productid = dbGet[0].ProductID;
                        newOrder.MaxOrder = dbGet[0].Quantity-1;


                                if (int.Parse(input) > 0 && int.Parse(input) < newOrder.MaxOrder)
                        {
                            //get quantity and adjust the products quantity
                            newOrder.Quantity = (int.Parse(input));
                            dbGet[0].Quantity -= newOrder.Quantity;
                            return newOrder;
                        }
                        else { Console.WriteLine("invalid quantity"); }
                    }
                    else
                    {
                        Console.WriteLine("invalid product");

                    }
                }
            }
            else
            {
                Console.WriteLine("Sending you back to main menu");

                runStore();



            }

        }
        else
        {
            Console.WriteLine("invalid input");

        }


    }



}

        public List<Order> findUserOrderHistory()
        {
            DbStoreContext db = new DbStoreContext();// set up dbcontext
            Cust find = new Cust();
            while (true)
            {
                //prompts user to enter id
                Console.WriteLine("Enter User ID");
                test = Console.ReadLine();
                //checks to make sure input is valid 
                if (Regex.IsMatch(test, idTest)) break;
                Console.WriteLine("Invalid input. Please use numbers only for this field.");
            }
            //adds id to user
            find.CustId = int.Parse(test);
            //get query results
            var searchResults = db.Order.Where(ord => ord.CustId == find.CustId).ToList();
            return searchResults;
        }

        public List<Order> findLocalOrderHistory()
        {
            DbStoreContext db = new DbStoreContext();
            var dbstores = db.StoreLocation.ToArray();
            ConsoleKey response;
            //prompts user to enter location ID
            Console.WriteLine("Enter Location ID");
            foreach (var store in dbstores)
            {
                Console.WriteLine($"{store.StoreLocationID}: {store.City}");
            }


            

            StoreLocation find = new StoreLocation();

            //cycle through stores
            while (true)
            {
                response = Console.ReadKey().Key;
                if (response == ConsoleKey.D1)
                {
                    find.StoreLocationID = 1;
                    break;
                }
                else if (response == ConsoleKey.D2)
                {
                    find.StoreLocationID = 2;
                    break;

                }
                else if (response == ConsoleKey.D3)
                {
                    find.StoreLocationID = 3;
                    break;

                }
                else
                {
                    Console.WriteLine("invalid, please enter a know store id");
                }
            }
            

    
            //query Order and save results
            var searchResults = db.Order.Where(ord => ord.Storeid == find.StoreLocationID).ToList();
            return searchResults;
        }
        public void adjustInventory()
        {
            DbStoreContext db = new DbStoreContext();
            var dbstores = db.StoreLocation.ToArray();
            int adjust;
            ConsoleKey response;
            //prompts user to enter location ID
            Console.WriteLine("Enter Location ID");
            foreach (var store in dbstores)
            {
                Console.WriteLine($"{store.StoreLocationID}: {store.City}");
            }


            



            //Cycle through locations
            while (true)
            {
                response = Console.ReadKey().Key;
                if (response == ConsoleKey.D1)
                {
                    adjust = 1;
                    break;
                }
                else if (response == ConsoleKey.D2)
                {
                    adjust = 2;
                    break;

                }
                else if (response == ConsoleKey.D3)
                {
                    adjust = 3;
                    break;

                }
                else
                {
                    Console.WriteLine("invalid, please enter a know store id");
                }
            }
            //query products and store
            List<Product> dbInventory = db.Product.Where(prod =>prod.StoreID==adjust).ToList();
            //prompt user to adjust quantity
            Console.WriteLine("Enter the name of the product would you like to adjust?");

           // loops for user to adjust quantity
            while (true)
            {
                int i = 0;
                List<string> inventory = new List<string>();


                foreach (Product p in dbInventory)
            {

                    Console.WriteLine($"{i}: {p.Name}");
                    inventory.Add(p.Name);
                    i++;
                }
            
            
                string prodName = Console.ReadLine();

                if (inventory.Contains(prodName))
                {
                    Console.WriteLine("What should the new Quantity be?");
                    var input = Console.ReadLine();
                   
                    if (int.Parse(input)>=0)
                    {
                        List<Product> dbProd = db.Product.Where(prod => prod.StoreID == adjust 
                        && prod.Name==prodName).ToList();
                        dbProd[0].Quantity = int.Parse(input);
                        break;


                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }

                }
                else {
                    Console.WriteLine("Invalid input, please try again");
                }
            }

        }


    }
}



     