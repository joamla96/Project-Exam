using System.Windows;
using System.Windows.Controls;

namespace UI.GUI.View
{
	/// <summary>
	/// Interaction logic for ReserveRoom.xaml
	/// </summary>
	public partial class ReserveRoom : Page
	{
		public ReserveRoom()
		{
			InitializeComponent();
		}
		private void ReserveRoomButtonClick(object sender, RoutedEventArgs e)
		{
			string date = SelectDate.Text;
			ComboBoxItem toSelected = (ComboBoxItem)ToComboBox.SelectedItem;
			string to = toSelected.Content.ToString();
			ComboBoxItem fromSelected = (ComboBoxItem)FromComboBox.SelectedItem;
			string from = fromSelected.Content.ToString();
			string peopleNr = NumberOfPeopleTextBox.Text;

			if (peopleNr == "")
			{
				MessageLabel.Content = "Enter number of people! ";
			}
			else
			{
				ViewModel.ReserveRoomVM reserveRoom = new ViewModel.ReserveRoomVM();
				MessageLabel.Content = reserveRoom.ReserveRoom(date, from, to, peopleNr);
			}
		}


	}
}
