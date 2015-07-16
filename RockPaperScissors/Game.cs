using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
	public class Game
	{
		private int PlayerCount = 2;

		#region Properties
		public int Round { get; set; }

		public List<Player> Players { get; set; }

		public int Ties { get; set; }

		#endregion

		#region constructor / setup
		public Game()
		{
			this.Players = new List<Player>();
		}

		public void CreatePlayers()
		{
			var counter = 0;
			while (counter < this.PlayerCount)
			{
				counter++;
				Console.WriteLine("Please enter a name for player {0}:", counter);
				var name = Console.ReadLine();

				this.Players.Add(new Player(name));
			}
		}
		#endregion 

		#region methods
		private void DetermineWinner()
		{
			var player1 = this.Players.First();
			var player2 = this.Players.Last();

			if (player1.Choice.Defeats.ContainsKey(player2.Choice.SelectedOption))
			{
				player1.WinCount++;
				WriteOutcome(player1, player2);
			}

			else if (player2.Choice.Defeats.ContainsKey(player1.Choice.SelectedOption))
			{
				player2.WinCount++;
				WriteOutcome(player2, player1);
			}
			else
			{
				this.Ties++;
				Console.WriteLine(String.Format("It's a draw! ({0} - {1})", player1.Choice.SelectedOption, player2.Choice.SelectedOption));
				WriteStandings();
			}
		}

		private void DisplayOptions()
		{
			Console.WriteLine("-- Round {0} --", this.Round);
			Console.WriteLine("Options (type \"exit\" to quit):");
			foreach (var option in Enum.GetValues(typeof(Option)))
				Console.WriteLine("\t" + (int)option + " - " + option);
		}

		public void Play()
		{
			var input = String.Empty;
			while (true)
			{
				this.Round++;
				foreach (var player in Players)
				{
					DisplayOptions();

					Console.WriteLine("{0} Selection: ", player.Name);
					input = Console.ReadLine();

					if (PlayerWantsToQuit(input))
						break;

					while (!player.SetChoice(input))
					{
						Console.Clear();
						Console.WriteLine("!!! \"{0}\" is not a valid choice! Please try again!", input, player.Name);
						DisplayOptions();
						Console.WriteLine("{0} Selection: ", player.Name);
						input = Console.ReadLine();
					}

					Console.Clear();
				}

				if (PlayerWantsToQuit(input))
					break;

				this.DetermineWinner();
			}

			Console.Clear();
			Console.WriteLine("Good game!");
			Console.WriteLine();
			WriteStandings();
			WriteGameResults();
		}

		private bool PlayerWantsToQuit(string input)
		{
			if (String.Equals(input, "exit", StringComparison.CurrentCultureIgnoreCase))
				return true;

			return false;
		}

		private void WriteGameResults()
		{
			foreach (var player in Players)
			{
				Console.WriteLine("{0} selection counts:", player.Name);
				foreach (var pair in player.Choices.OrderByDescending(c => c.Value))
					Console.WriteLine("\t{0} - {1}", pair.Key.ToString(), pair.Value);
			}
		}

		private void WriteOutcome(Player winner, Player loser)
		{
			string verb = winner.Choice.Defeats[loser.Choice.SelectedOption];
			string outcome = String.Format("{3} ({0}) {1} {4} ({2})",
				winner.Choice.SelectedOption,
				verb,
				loser.Choice.SelectedOption,
				winner.Name,
				loser.Name);
			Console.WriteLine(outcome);

			WriteStandings();
			Console.WriteLine();
		}

		private void WriteStandings()
		{
			foreach (var player in this.Players)
			{
				Console.WriteLine("{0} {1} {2}", player.Name, player.WinCount, player.WinCount == 1 ? "win" : "wins");
			}
			
			Console.WriteLine("{0} {1}", this.Ties, this.Ties == 1 ? "tie" : "ties");
			Console.WriteLine();
		}

		#endregion
	}
}
