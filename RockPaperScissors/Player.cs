using RockPaperScissors.Options;
using System;
using System.Collections.Generic;

namespace RockPaperScissors
{
	public class Player
	{
		public Choice Choice { get; set; }
		public string Name { get; set; }
		public int WinCount { get; set; }
		public Dictionary<Option, int> Choices { get; set; }

		public Player(string name)
		{
			this.Name = name;
			this.Choices = new Dictionary<Option, int>();
		}

		public bool SetChoice(string selectedOption)
		{
			try
			{
				var option = (Option)Enum.Parse(typeof(Option), selectedOption, true);
				
				this.Choice = Choice.GetDerived(option);
				this.Choice.SelectedOption = option;

				if (!this.Choices.ContainsKey(option))
					this.Choices.Add(option, 1);
				else
					this.Choices[option]++;

				return true;
			}
			catch (Exception)
			{
				return false;				
			}
		}

	}
}
