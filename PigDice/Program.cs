using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PigDice {
	class Program {

		Random rnd = new Random();

		int RollDie() {
			return rnd.Next(1, 7);
		}

		void PlayPigDice() {
			int score = 0;
			int die = RollDie();
			while(die != 1) {
				score += die;
				die = RollDie();
			}
			Console.WriteLine("Score is {0}", score);
		}

		void Run() {
			bool quit = false;
			while(!quit) {
				PlayPigDice();

				Console.Write("Do you want to quit? ");
				string answer = Console.ReadLine();
				answer = answer.ToUpper();
				quit = answer.StartsWith("Y");
			}
		}
		void Run2() {
			int score = 0;
			for(int idx = 0; idx < 1000000; idx++) {
				score += RollDie();
			}
			Console.WriteLine($"Score is {score}");
		}
		static void Main(string[] args) {
			(new Program()).Run2();
		}
	}
}
