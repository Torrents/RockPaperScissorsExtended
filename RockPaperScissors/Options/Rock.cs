using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors.Options
{
	public class Rock : Choice
	{
		public Rock()
		{
			this.Defeats.Add(Option.Scissors, "crushes");
			this.Defeats.Add(Option.Lizard, "crushes");
		}
	}
}
