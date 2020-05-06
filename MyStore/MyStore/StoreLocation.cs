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
    //This class populates StoreLocation
    public class StoreLocation
    {
        
        public int StoreLocationID { get; set; }

        

        private string city;
        public string City
        {
            get { return city; }
            set { city = value; }
        }

        public StoreLocation() { }

 
    



    }
}
