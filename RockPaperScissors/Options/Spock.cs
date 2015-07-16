using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Options
{
	public class Spock : Choice
	{
		public Spock()
		{
			this.Defeats.Add(Option.Scissors, "Smashes");
			this.Defeats.Add(Option.Rock, "Vaporizes");
		}
	}
}
