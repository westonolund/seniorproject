using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PresentationLayer
{
	/// <summary>
	/// Interaction logic for PlayerWindowPitching.xaml
	/// </summary>
	public partial class PlayerWindowPitching : Window
	{
		private DBConnection _daLayer = new DBConnection();
		private PlayerAccessLayer _playerAccessor = new PlayerAccessLayer();
		public PlayerWindowPitching(string playerFirstName, string playerSecondName)
		{
			InitializeComponent();
			try
			{
				var results = _playerAccessor.getPlayerPitching(playerFirstName, playerSecondName);
				LossesTextBox.Text = results.Losses.ToString();
				WinsTextBox.Text = results.Wins.ToString();
				SavesTextBox.Text = results.Saves.ToString();
				ERATextBox.Text = results.ERA.ToString();
				CompleteGamesTextBox.Text = results.CompleteGames.ToString();
				ShutoutsTextBox.Text = results.Shutouts.ToString();
				StrikeoutsTextBox.Text = results.StrikeOuts.ToString();				
				PlayerNameLbl.Content = results.FirstName.ToString() + " " + results.LastName.ToString();
			}
			catch (NullReferenceException)
			{
				MessageBox.Show("Player not found", "Error");
				this.Close();
			}
		}
	}
}
