using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Options
{
	public class Lizard : Choice
	{
		public Lizard()
		{
			this.Defeats.Add(Option.Spock, "Poisons");
			this.Defeats.Add(Option.Paper, "Eats");
		}
	}
}
