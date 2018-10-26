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

		int PlayPigDice() {
			int score = 0;
			int die = RollDie();
			while(die != 1) {
				score += die;
				die = RollDie();
			}
			//Console.WriteLine("Score is {0}", score);
			return score;
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
		void RunForBootcampRecord(string taskName) {
			int BestScoreSoFar = 0;
			long GameCount = 0;
			while (true) {
				int score = PlayPigDice();
				GameCount++;
				if (score > BestScoreSoFar) {
					BestScoreSoFar = score;
					Display(taskName, GameCount, BestScoreSoFar);
				}
				if (++GameCount % 1000000000 == 0)
					Display(taskName, GameCount, BestScoreSoFar);
			}
		}
		void Display(string taskName, long games, int score) {
			Console.WriteLine($"Task: {taskName}; Game: {games.ToString("N0")}; Score: {score.ToString("N0")}");
			System.Diagnostics.Debug.WriteLine($"Task: {taskName}; Game: {games.ToString("N")}, Score: {score.ToString("N")}");
		}
		void Pause() {
			Console.Beep();
			Console.ReadKey();
		}

		Task StartTask(string taskName) {
			Action<object> pigdice = (object name) => { RunForBootcampRecord(name.ToString()); };
			Task t = new Task(pigdice, taskName);
			t.Start();
			//t.Wait();
			return t;
		}
		void StartTasks() {
			Task t1 = StartTask("t1");
			Task t2 = StartTask("t2");
			while (!t1.IsCompleted && !t2.IsCompleted) {

			}
		}

		static void Main(string[] args) {
			(new Program()).StartTasks();
		}
	}
}
