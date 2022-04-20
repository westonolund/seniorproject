using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataObjects;

namespace DataAccessLayer
{
	
	public class TeamAccessLayer
	{
		private DBConnection _daLayer = new DBConnection();



		public List<string> getAllTeamAbbreviations()
		{
			List<string> results = new List<string>();
			MySqlCommand cmd = new MySqlCommand("CALL GetTeamAbrv()", _daLayer.connection);
			try
			{
				_daLayer.connectToDatabase();
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					results.Add(reader.GetString(0));
				}
			}
			catch(MySqlException ex)
			{
				throw new Exception(ex.Message);
			}
			finally
			{
				_daLayer.closeDatabase();
			}
			return results;
		}

		public List<PitchingStats> getTeamPitching(string TeamAbrv)
		{
			List<PitchingStats> results = new List<PitchingStats>();
			string commandString = "CALL GetTeamPitching(\"" + TeamAbrv + "\");";
			MySqlCommand cmd = new MySqlCommand(commandString, _daLayer.connection);

			try
			{
				_daLayer.connectToDatabase();
				MySqlDataReader reader = cmd.ExecuteReader();
				while(reader.Read())
				{
					var teampitching = new PitchingStats()
					{
						Rank = reader.GetInt32(0),
						FirstName = reader.GetString(1),
						LastName = reader.GetString(2),
						StrikeOuts = reader.GetInt32(3),
						Year = reader.GetInt32(4),
						Age = reader.GetInt32(5),
						TeamAbrv = reader.GetString(6),
						League = reader.GetString(7),
						GamesPitched = reader.GetInt32(8),
						GamesStarted = reader.GetInt32(9),
						CompleteGames = reader.GetInt32(10),
						Shutouts = reader.GetInt32(11),
						Wins = reader.GetInt32(12),
						Losses = reader.GetInt32(13),
						WinLossPercent = reader.GetDouble(14),
						Saves = reader.GetInt32(15),
						InningsPitched = reader.GetInt32(16),
						HitsAllowed = reader.GetInt32(17),
						RunsAllowed = reader.GetInt32(18),
						EarnedRunsAllowed = reader.GetInt32(19),
						Walks = reader.GetInt32(20),
						ERA = reader.GetDouble(21),
						Pitches = reader.GetInt32(22),
						Strikes = reader.GetInt32(23)
					};
					results.Add(teampitching);
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
			return results;
		}
		
		public List<BattingStats> getTeamBatting(string TeamAbrv)
		{
			List<BattingStats> results = new List<BattingStats>();
			string commandString = "CALL GetTeamBatting(\"" + TeamAbrv + "\");";
			MySqlCommand cmd = new MySqlCommand(commandString, _daLayer.connection);

			try
			{
				_daLayer.connectToDatabase();
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					var teamBatting = new BattingStats()
					{
						Rank = reader.GetInt32(0),
						FirstName = reader.GetString(1),
						LastName = reader.GetString(2),
						Homeruns = reader.GetInt32(3),
						Year = reader.GetInt32(4),
						Age = reader.GetInt32(5),
						TeamAbrv = reader.GetString(6),
						League = reader.GetString(7),
						GamesPlayed = reader.GetInt32(8),
						PlateAppearances = reader.GetInt32(9),
						AtBats = reader.GetInt32(10),
						Runs = reader.GetInt32(11),
						Hits = reader.GetInt32(12),
						RBI = reader.GetInt32(13),
						Walks = reader.GetInt32(14),
						StrikeOuts = reader.GetInt32(15),
						StolenBases = reader.GetInt32(16),
						BattingAvg = reader.GetDouble(17),
						OnBasePercentage = reader.GetDouble(18),
						Position = reader.GetString(19)
					};
					results.Add(teamBatting);
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
			return results;
		}
	}
}
