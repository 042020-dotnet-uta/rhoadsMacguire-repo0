using System;
using System.Collections.Generic;
using  Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Sqlite;
using Microsoft.EntityFrameworkCore;
//using Microsoft.Extensions.Logging.Console;

namespace rockPaperScissors
{
	class Player
	{
		
        public string Name { get; set; }

		public string Choice { get; set; }

		public int PlayerID { get; set; }

		public int wins=0;

		public List <string> choices= new List <string> ();
        
		
		}
	}

