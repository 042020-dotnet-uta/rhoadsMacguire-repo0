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
    public class DbStoreContext: DbContext
    {

        public DbSet<User> User { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<StoreLocation> StoreLocation { get; set; }
        public DbSet<Inventory> Inventory { get; set; }
        //public DbSet<Program> Program { get; set; }
        public DbStoreContext() { }
        public DbStoreContext(DbContextOptions<DbStoreContext> options)
                   : base(options)
        { }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlite("Datasource=store.db");
            }
        }

    }
}
