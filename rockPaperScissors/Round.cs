using System;
using System.Collections.Generic;

namespace rockPaperScissors
{
	 class Round
	{
		

        private Player winner;

        public string user1Choice { get; set; }
		public string user2Choice { get; set; }
		public Player Winner { get => winner; set => winner = value; }
	}

		}
