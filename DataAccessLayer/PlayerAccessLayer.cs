using DataObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
	public class PlayerAccessLayer
	{
		private DBConnection _daLayer = new DBConnection();

		public PitchingStats getPlayerPitching(string playerFirstName, string playerSecondName)
		{
			PitchingStats stats = new PitchingStats();
			string commandString = "CALL GetPlayerPitching(\"" +playerFirstName + "\", \""  + playerSecondName + "\");";
			MySqlCommand cmd = new MySqlCommand(commandString, _daLayer.connection);
			try
			{
				_daLayer.connectToDatabase();
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{

						stats.Rank = reader.GetInt32(0);
						stats.FirstName = reader.GetString(1);
						stats.LastName = reader.GetString(2);
						stats.StrikeOuts = reader.GetInt32(3);
						stats.Year = reader.GetInt32(4);
						stats.Age = reader.GetInt32(5);
						stats.TeamAbrv = reader.GetString(6);
						stats.League = reader.GetString(7);
						stats.GamesPitched = reader.GetInt32(8);
						stats.GamesStarted = reader.GetInt32(9);
						stats.CompleteGames = reader.GetInt32(10);
						stats.Shutouts = reader.GetInt32(11);
						stats.Wins = reader.GetInt32(12);
						stats.Losses = reader.GetInt32(13);
						stats.WinLossPercent = reader.GetDouble(14);
						stats.Saves = reader.GetInt32(15);
						stats.InningsPitched = reader.GetInt32(16);
						stats.HitsAllowed = reader.GetInt32(17);
						stats.RunsAllowed = reader.GetInt32(18);
						stats.EarnedRunsAllowed = reader.GetInt32(19);
						stats.Walks = reader.GetInt32(20);
						stats.ERA = reader.GetDouble(21);
						stats.Pitches = reader.GetInt32(22);
						stats.Strikes = reader.GetInt32(23);
				}
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				_daLayer.closeDatabase();
			}
			return stats;
		}

		public BattingStats getPlayerBatting(string playerFirstName, string playerSecondName)
		{
			BattingStats stats = new BattingStats();
			string commandString = "CALL GetPlayerBatting(\"" + playerFirstName + "\", \"" + playerSecondName + "\");";
			MySqlCommand cmd = new MySqlCommand(commandString, _daLayer.connection);
			try
			{
				_daLayer.connectToDatabase();
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					stats.Rank = reader.GetInt32(0);
					stats.FirstName = reader.GetString(1);
					stats.LastName = reader.GetString(2);
					stats.Homeruns = reader.GetInt32(3);
					stats.Year = reader.GetInt32(4);
					stats.Age = reader.GetInt32(5);
					stats.TeamAbrv = reader.GetString(6);
					stats.League = reader.GetString(7);
					stats.GamesPlayed = reader.GetInt32(8);
					stats.PlateAppearances = reader.GetInt32(9);
					stats.AtBats = reader.GetInt32(10);
					stats.Runs = reader.GetInt32(11);
					stats.Hits = reader.GetInt32(12);
					stats.RBI = reader.GetInt32(13);
					stats.Walks = reader.GetInt32(14);
					stats.StrikeOuts = reader.GetInt32(15);
					stats.StolenBases = reader.GetInt32(16);
					stats.BattingAvg = reader.GetDouble(17);
					stats.OnBasePercentage = reader.GetDouble(18);
					stats.Position = reader.GetString(19);
				}
			}
			catch (MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				_daLayer.closeDatabase();
			}
			return stats;
		}
	}
}
