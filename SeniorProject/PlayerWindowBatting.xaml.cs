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
	/// Interaction logic for PlayerWindowBatting.xaml
	/// </summary>
	public partial class PlayerWindowBatting : Window
	{
		private DBConnection _daLayer = new DBConnection();
		private PlayerAccessLayer _playerAccessor = new PlayerAccessLayer();
		public PlayerWindowBatting(string playerFirstName, string playerSecondName)
		{
			InitializeComponent();
			try
			{
				var results = _playerAccessor.getPlayerBatting(playerFirstName, playerSecondName);
				HitsTextBox.Text = results.Hits.ToString();
				StrikeoutsTextBox.Text = results.StrikeOuts.ToString();
				HomeRunsTextBox.Text = results.Homeruns.ToString();
				RBIsTextBox.Text = results.RBI.ToString();
				BattingAverageTextBox.Text = results.BattingAvg.ToString();
				TeamTextBox.Text = results.TeamAbrv.ToString();
				PositionTextBox.Text = results.Position.ToString();
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
