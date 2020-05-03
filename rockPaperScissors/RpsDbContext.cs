using System;
//using System.Collections.Generic;
//using System.Text;
//using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace rockPaperScissors
{
    class RpsDbContext : DbContext
    {
        public DbSet<Player> Players { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Program> Programs { get; set; }

        protected override void OnConfiguring
            (DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlite("Data Source=rps.db"); 
        }


    }
}
