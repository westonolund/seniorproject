using DataObjects;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
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

		public List<BattingStats> getPositionBatting(string positionSelected)
		{
			List<BattingStats> results = new List<BattingStats>();
			string commandString = "CALL GetPositionBatting(\"" + positionSelected + "\");";
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

		public List<Player> getPlayersBatting()
		{
			List<Player> players = new List<Player>();
			string commandString = "CALL GetPlayersBatting();";
			MySqlCommand cmd = new MySqlCommand(commandString, _daLayer.connection);
			try
			{
				_daLayer.connectToDatabase();
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					var player = new Player()
					{
						firstName = reader.GetString(0),
						lastName = reader.GetString(1),
						position = reader.GetString(2),
						teamAbrv = reader.GetString(3)
					};
					players.Add(player);
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
			return players;
		}

		public List<Player> getPlayersPitching()
		{
			List<Player> players = new List<Player>();
			string commandString = "CALL GetPlayersPitching();";
			MySqlCommand cmd = new MySqlCommand(commandString, _daLayer.connection);
			try
			{
				_daLayer.connectToDatabase();
				MySqlDataReader reader = cmd.ExecuteReader();
				while (reader.Read())
				{
					var player = new Player()
					{
						firstName = reader.GetString(0),
						lastName = reader.GetString(1),
						position = "P",
						teamAbrv = reader.GetString(2)
					};
					players.Add(player);
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
			return players;
		}
		
	}
}
