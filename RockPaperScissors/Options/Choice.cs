using System;
using System.Collections.Generic;

namespace RockPaperScissors.Options
{
	public class Choice
	{
		public static string SubclassNamePrefix = "RockPaperScissors.Options.";

		public Option SelectedOption { get; set; }
		public Dictionary<Option, string> Defeats { get; set; }

		public Choice()
		{
			this.Defeats = new Dictionary<Option, string>();
		}

		public static Choice GetDerived(Option option)
		{
			var assembly = typeof(Choice).Assembly;
			var type = assembly.GetType(Choice.SubclassNamePrefix + option.ToString());

			return (Choice)Activator.CreateInstance(type);
		}
	}
}
