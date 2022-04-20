using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
	public class PitchingStats
	{
		public int Rank { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int StrikeOuts { get; set; }
		public int Year { get; set; }
		public int Age { get; set; }
		public string TeamAbrv { get; set; }
		public string League { get; set; }
		public int GamesPitched { get; set; }
		public int GamesStarted { get; set; }
		public int CompleteGames { get; set; }
		public int Shutouts { get; set; }
		public int Wins { get; set; }
		public int Losses { get; set; }
		public double WinLossPercent { get; set; }
		public int Saves { get; set; }
		public int InningsPitched { get; set; }
		public int HitsAllowed { get; set; }
		public int RunsAllowed { get; set; }
		public int EarnedRunsAllowed { get; set; }
		public int Walks { get; set; }
		public double ERA { get; set; }
		public int Pitches { get; set; }
		public int Strikes { get; set; }
	}

}
