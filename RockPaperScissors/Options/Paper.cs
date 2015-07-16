using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Options
{
	public class Paper : Choice
	{
		public Paper()
		{
			this.Defeats.Add(Option.Rock, "Covers");
			this.Defeats.Add(Option.Spock, "Disproves");
		}
	}
}
