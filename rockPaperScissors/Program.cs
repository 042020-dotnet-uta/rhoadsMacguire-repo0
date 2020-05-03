using System;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging.Console;

namespace rockPaperScissors
{
    class Program
    {
        public int ProgramID { get; set; }
        static void Main(string[] args)
        { 
             //initialize logger
            var serviceCo = new ServiceCollection();
            ConfigureServices(serviceCo);

            //prepare logger for game, to be disposed of on game end
            using (ServiceProvider serviceProvider = serviceCo.BuildServiceProvider())
            {
                //initialize game with logger
            Game startGame= serviceProvider.GetService<Game>();
            var db = new RpsDbContext();
            startGame.runGame();








        }
        }
                //Method taken from Mark's RPS Project example
         static void ConfigureServices(ServiceCollection serviceCo)
        {
            serviceCo.AddLogging(configure => configure.AddConsole())
            .AddTransient<Game>();
    }

    }
    }