using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Options
{
	public class Scissors : Choice
	{
		public Scissors()
		{
			this.Defeats.Add(Option.Paper, "Cuts");
			this.Defeats.Add(Option.Lizard, "Decapitates");
		}
	}
}
