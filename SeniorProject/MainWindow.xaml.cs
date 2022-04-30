using DataAccessLayer;
using System.Windows;
using System.Collections.Generic;
using PresentationLayer;
using System;
using System.Text.RegularExpressions;
using DataObjects;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace SeniorProject


{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DBConnection _daLayer = new DBConnection();
		private TeamAccessLayer _teamAccessor = new TeamAccessLayer();
		private List<Player> _players = new List<Player>();
		private PlayerAccessLayer _playerAccessor = new PlayerAccessLayer();
		private bool advancedSearch = false;
		public MainWindow()
		{
			InitializeComponent();
			// get all players
			List<Player> battingPlayers = new List<Player>();
			List<Player> pitchingPlayers = new List<Player>();
			battingPlayers = _playerAccessor.getPlayersBatting();
			pitchingPlayers = _playerAccessor.getPlayersPitching();
			foreach (var item in battingPlayers)
			{
				_players.Add(item);
			}
			foreach (var item in pitchingPlayers)
			{
				_players.Add(item);
			}

			// list of positions and populate combo boxes for positions
			List<string> positions = new List<string>();
			positions.Add("C");
			positions.Add("1B");
			positions.Add("2B");
			positions.Add("3B");
			positions.Add("SS");
			positions.Add("LF");
			positions.Add("CF");
			positions.Add("RF");

			for (int i = 0; i < positions.Count; i++)
			{
				PositionDropDownSearch.Items.Add(positions[i]);
				PositionDropDown.Items.Add(positions[i]);
			}
			PositionDropDown.DataContext = positions;
			PositionDropDown.SelectedIndex = 0;
			PositionDropDownSearch.DataContext = positions;

			
			
			List<string> teamAbrv = new List<string>();

			// get all team abbreviations
			teamAbrv = _teamAccessor.getAllTeamAbbreviations();	
		
			// populate the drop down for teams
			for(var i = 0; i < teamAbrv.Count; i++)
			{
				TeamDropDown.Items.Add(teamAbrv[i]);
				TeamDropDownSearch.Items.Add(teamAbrv[i]);
			}
			TeamDropDown.DataContext = teamAbrv;
			TeamDropDownSearch.DataContext = teamAbrv;
			TeamDropDown.SelectedIndex=0;

			// checking the pitching by default for player search
			PlayerPitchingRadioButton.IsChecked = true;
		}

		// Event handler for search team button
		private void SearchTeam_Click(object sender, RoutedEventArgs e)
		{
			// if looking for pitching info
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
			// if looking for batting info
			if (TeamBattingRadioButton.IsChecked == true)
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

		// event handler for searching by player button
		private void SearchPlayerBtn_Click(object sender, RoutedEventArgs e)
		{
			// if looking for pitching
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
			// if looking for batting
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

		// event handler for button being released in search text box (autocomplete text feature)
		private void SearchPlayerTxtBox_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
		{
			bool found = false;
			var border = (resultStack.Parent as ScrollViewer).Parent as Border;

			string query = (sender as TextBox).Text;

			if (query.Length == 0)
			{
				//Clear
				resultStack.Children.Clear();
				border.Visibility = System.Windows.Visibility.Collapsed;
			}
			else
			{
				border.Visibility = System.Windows.Visibility.Visible;
			}

			//Clear the list
			resultStack.Children.Clear();

			//Add the result
			foreach(Player player in _players)
			{
				// if normal search
				if(advancedSearch == false) 
				{
					if (
					// pitching first name search
					(player.firstName.ToLower().StartsWith(query.ToLower()) && PlayerPitchingRadioButton.IsChecked == true && player.position == "P")
					// pitching last name search
					|| (player.lastName.ToLower().StartsWith(query.ToLower()) && PlayerPitchingRadioButton.IsChecked == true && player.position == "P")
					// Batting search first name
					|| (player.firstName.ToLower().StartsWith(query.ToLower()) && PlayerBattingRadioButton.IsChecked == true && player.position != "P")
					// Batting search last name
					|| (player.lastName.ToLower().StartsWith(query.ToLower()) && PlayerBattingRadioButton.IsChecked == true && player.position != "P")
					)
					{
						// Word starts with this
						addItem(player);
						found = true;
					}
				}
				// if advanced search
				if(advancedSearch == true)
				{
					if (
					// pitching first name search
					(player.firstName.ToLower().StartsWith(query.ToLower()) && PlayerPitchingRadioButton.IsChecked == true && player.position == "P" && player.teamAbrv == TeamDropDownSearch.Text.ToString())
					// pitching last name search
					|| (player.lastName.ToLower().StartsWith(query.ToLower()) && PlayerPitchingRadioButton.IsChecked == true && player.position == "P" && player.teamAbrv == TeamDropDownSearch.Text.ToString())
					// Batting search first name
					|| (player.firstName.ToLower().StartsWith(query.ToLower()) && PlayerBattingRadioButton.IsChecked == true && player.teamAbrv == TeamDropDownSearch.Text.ToString() && player.position.Contains(PositionDropDownSearch.Text.ToString()))
					// Batting search last name
					|| (player.lastName.ToLower().StartsWith(query.ToLower()) && PlayerBattingRadioButton.IsChecked == true && player.teamAbrv == TeamDropDownSearch.Text.ToString() && player.position.Contains(PositionDropDownSearch.Text.ToString()))
					)
					{
						// Word starts with this
						addItem(player);
						found = true;
					}
				}
				
			}
			if(!found)
			{
				resultStack.Children.Add(new TextBlock() { Text = "No results found." });
			}
		}

		// adding items to the panel list
		private void addItem(Player player)
		{
			TextBlock block = new TextBlock();

			//add the text 
			block.Text = player.firstName + " " + player.lastName;

			block.Margin = new Thickness(2, 3, 3, 3);
			block.Cursor = Cursors.Hand;

			// Mouse events   
			block.MouseLeftButtonUp += (sender, e) =>
			{
				SearchPlayerTxtBox.Text = (sender as TextBlock).Text;
			};

			block.MouseEnter += (sender, e) =>
			{
				TextBlock b = sender as TextBlock;
				b.Background = Brushes.PeachPuff;
			};

			block.MouseLeave += (sender, e) =>
			{
				TextBlock b = sender as TextBlock;
				b.Background = Brushes.Transparent;
			};

			// Add to the panel   
			resultStack.Children.Add(block);
		}

		// event handler for advanced search on click
		private void btnOn_Click(object sender, RoutedEventArgs e)
		{
			advancedSearch = true;
			Teamlbl.Visibility = Visibility.Visible;
			Positionlbl.Visibility = Visibility.Visible;
			TeamDropDownSearch.Visibility = Visibility.Visible;
			PositionDropDownSearch.Visibility = Visibility.Visible;
			if (PlayerPitchingRadioButton.IsChecked == true)
			{
				PositionDropDownSearch.IsEnabled = false;
			}
		}

		// event handler for advanced search off click
		private void btnOff_Click(object sender, RoutedEventArgs e)
		{
			advancedSearch = false;
			Teamlbl.Visibility = Visibility.Collapsed;
			Positionlbl.Visibility = Visibility.Collapsed;
			TeamDropDownSearch.Visibility = Visibility.Collapsed;
			PositionDropDownSearch.Visibility = Visibility.Collapsed;
		}

		// event handler for player pitching radio button checked
		private void PlayerPitchingRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			PositionDropDownSearch.IsEnabled = false;
		}

		// event handler for player batting radio button checked
		private void PlayerBattingRadioButton_Checked(object sender, RoutedEventArgs e)
		{
			PositionDropDownSearch.IsEnabled = true;
		}

		// event handler for search by position button
		private void SearchPosition_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				PositionBattingWindow win1 = new PositionBattingWindow(PositionDropDown.SelectedItem.ToString());
				win1.Show();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error" + ex);
			}

		}
	}
}
