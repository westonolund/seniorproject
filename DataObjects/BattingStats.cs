using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataObjects
{
	public class BattingStats
	{
		public int Rank { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int Homeruns { get; set; }
		public int Year { get; set; }
		public int Age { get; set; }
		public string TeamAbrv { get; set; }
		public string League { get; set; }
		public int GamesPlayed { get; set; }
		public int PlateAppearances { get; set; }
		public int AtBats { get; set; }
		public int Runs { get; set; }
		public int Hits {get; set; }
		public int RBI { get; set; }
		public int Walks { get; set; }
		public int StrikeOuts { get; set; }
		public int StolenBases { get; set; }
		public double BattingAvg { get; set; }
		public double OnBasePercentage { get; set; }
		public string Position { get; set; }
	}
	

}
