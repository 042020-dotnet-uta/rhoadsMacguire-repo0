using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
namespace MyStore
{
    public class Program
    {
        static void Main(string[] args)
        {


            var serviceCo = new ServiceCollection();
            ConfigureServices(serviceCo);
            

            using (ServiceProvider serviceProvider = serviceCo.BuildServiceProvider())
            {
                OpenStore op = serviceProvider.GetService<OpenStore>();
                User initialUser;
                while (true)
                {
                    initialUser = op.nextUser();
                    if (initialUser != null)
                    {
                        Console.WriteLine($"New User# {initialUser.ID} created for {initialUser.Fname} {initialUser.Lname} ");
                    }
                    else
                    {
                        Console.WriteLine("Customer creating cancelled.");
                        continue;
                    }
                }
            }





        }
        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddLogging(configure =>
            {
               // configure.AddConsole();
                configure.ClearProviders();
                configure.SetMinimumLevel(LogLevel.Information);
            }
                ).AddTransient<OpenStore>();
        }
    }
}
/*

String [] user =Console.ReadLine().Split(" ", 2, StringSplitOptions.RemoveEmptyEntries);
// check if user exists already
//if so Console.WriteLine("Welcome Back")

// if not
User customer = new User();
customer.Fname = user[0];
customer.Lname = user[1];

Console.WriteLine($"Hi {customer.Fname}! Looks like your new here! please complete your profile");
Console.WriteLine("Enter your steet address, city, state and zip code seperated by commas");

customer.Address = Console.ReadLine();

string  city = customer.Address.Split(", ", 4)[1];
StoreLocation thisStore = new StoreLocation();
thisStore.City = city;

Console.WriteLine("Enter your email");

customer.Email = Console.ReadLine();
thisStore.Inventory = new List<string>();

thisStore.Inventory.Add("a");
thisStore.Inventory.Add("b");

Console.WriteLine("Thanks!");
Console.WriteLine($"Looks like you are shopping at our {city} location");
string key = " ";
customer.Cart = new List<string>();
while (!thisStore.Inventory.Contains(key)){
    Console.WriteLine("What product would you like to buy today?" +
        " To see a list of products type \"List\" and press enter");
     key = Console.ReadLine();
    if (key.ToUpper() == "LIST")
    {
        foreach (String p in thisStore.Inventory)
        {
            Console.WriteLine(p);

        }

    }
    else if (!thisStore.Inventory.Contains(key))
    {
        Console.WriteLine("We do not have that product. Here are or products:");
        foreach (String p in thisStore.Inventory)
        {
            Console.WriteLine(p);

        }

    }
    else
    {
        customer.Cart.Add(key);
    }
}
Console.WriteLine("your cart contains: "+ customer.Cart[0]);



*/


