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
	/// Interaction logic for TeamBattingWindow.xaml
	/// </summary>
	public partial class TeamBattingWindow : Window
	{
		private DBConnection _daLayer = new DBConnection();
		private TeamAccessLayer _teamAccessor = new TeamAccessLayer();
		public TeamBattingWindow(string teamSelected)
		{
			InitializeComponent();
			try
			{
				TeamDataGrid.ItemsSource = _teamAccessor.getTeamBatting(teamSelected);
				this.Title="Team Batting " + teamSelected;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		}
	}
}
