using System;
using System.Collections.Generic;
using  Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace rockPaperScissors
{
    class Program
    {
        static void Main(string[] args)
        { 
             //initialize logger
            var serviceCo = new ServiceCollection();
           // ConfigureServices(serviceCo);

            //prepare logger for game, to be disposed of on game end
            using (ServiceProvider serviceProvider = serviceCo.BuildServiceProvider())
            {
                //initialize game with logger
            Game newGame= serviceProvider.GetService<Game>();
            newGame.runGame();








        }
                //Method taken from Mark's RPS Project example
         static void ConfigureServices(ServiceCollection serviceCo)
        {
            serviceCo.AddLogging(configure => configure.AddConsole())
            .AddTransient<Gameplay>();
    }
}
    }
    }