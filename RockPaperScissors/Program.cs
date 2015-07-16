using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissors
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Welcome to Rock, Paper, Scissors Extended!");

			var game = new Game();
			game.CreatePlayers();
			game.Play();

			Console.ReadLine();
		}
	}
}
