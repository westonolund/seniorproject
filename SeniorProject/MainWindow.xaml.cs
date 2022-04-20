using DataAccessLayer;
using System.Windows;
using System.Collections.Generic;
using PresentationLayer;
using System;
using System.Text.RegularExpressions;

namespace SeniorProject


{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DBConnection _daLayer = new DBConnection();
		private TeamAccessLayer _teamAccessor = new TeamAccessLayer();
		public MainWindow()
		{
			InitializeComponent();
			List<string> results = new List<string>();

			// get all team abbreviations
			results = _teamAccessor.getAllTeamAbbreviations();	
		
			// populate the drop down for teams
			for(var i = 0; i < results.Count; i++)
			{
				TeamDropDown.Items.Add(results[i]);
			}
			TeamDropDown.DataContext = results;
			TeamDropDown.SelectedIndex=0;
			
			
		}

		private void SearchTeam_Click(object sender, RoutedEventArgs e)
		{
			if (TeamPitchingRadioButton.IsChecked == true)
			{
				try
				{
					TeamPitchingWindow win1 = new TeamPitchingWindow(TeamDropDown.SelectedItem.ToString());
					win1.Show();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error" + ex);
				}
				
			}
			if(TeamBattingRadioButton.IsChecked == true)
			{
				try
				{
					TeamBattingWindow win1 = new TeamBattingWindow(TeamDropDown.SelectedItem.ToString());
					win1.Show();
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error" + ex);
				}
				
			}
		}

		private void SearchPlayerBtn_Click(object sender, RoutedEventArgs e)
		{
			if(PlayerPitchingRadioButton.IsChecked == true)
			{
				try
				{
					string pattern = "[ ,]+";
					string input = SearchPlayerTxtBox.Text.ToString();
					string[] names = Regex.Split(input, pattern);
					PlayerWindowPitching win1 = new PlayerWindowPitching(names[0], names[1]);
					win1.Show();
				}
				catch (IndexOutOfRangeException)
				{
					MessageBox.Show("You must enter a first and last name to search.", "Error");
				}
				catch (InvalidOperationException)
				{
					// Still wants to try and show window even if this exception occurs for some reason
				}
			}
			if(PlayerBattingRadioButton.IsChecked == true)
			{
				try
				{
					string pattern = "[ ,]+";
					string input = SearchPlayerTxtBox.Text.ToString();
					string[] names = Regex.Split(input, pattern);
					PlayerWindowBatting win1 = new PlayerWindowBatting(names[0], names[1]);
					win1.Show();
				}
				catch (IndexOutOfRangeException)
				{
					MessageBox.Show("You must enter a first and last name to search.", "Error");
				}
				catch(InvalidOperationException)
				{
					// Still wants to try and show window even if this exception occurs for some reason
				}
			}
			
			
		}
	}
}
