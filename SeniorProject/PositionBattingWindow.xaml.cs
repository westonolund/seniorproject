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
	/// Interaction logic for PositionBattingWindow.xaml
	/// </summary>
	public partial class PositionBattingWindow : Window
	{
		private DBConnection _daLayer = new DBConnection();
		private PlayerAccessLayer _playerAccessor = new PlayerAccessLayer();

		public PositionBattingWindow(string positionSelected)
		{
			InitializeComponent();

			try
			{
				PositionDataGrid.ItemsSource = _playerAccessor.getPositionBatting(positionSelected);
				this.Title = "Positional Batting " + positionSelected;
			}
			catch (Exception ex)
			{

				MessageBox.Show(ex.Message);
			}

		}
	}
}
