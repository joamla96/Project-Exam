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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.GUI.ViewModel;
using Core.Interfaces;

namespace UI.GUI.View
{
	/// <summary>
	/// Interaction logic for ReserveRoomAdminV.xaml
	/// </summary>
	public partial class ReserveRoomAdminV : Page
	{

		ReserveRoomAdminVM VM = new ReserveRoomAdminVM();
		public ReserveRoomAdminV()
		{
			InitializeComponent();
			UpdateRoomsList();
		}



		public void UpdateRoomsList()
		{
			if (DateAdminDatePicker != null && ToAdminComboBox != null && FromAdminComboBox != null && RoomListAdminListBox != null)
			{
				string date = DateAdminDatePicker.Text;
				ComboBoxItem toSelected = (ComboBoxItem)ToAdminComboBox.SelectedItem;
				string to = toSelected.Content.ToString();
				ComboBoxItem fromSelected = (ComboBoxItem)FromAdminComboBox.SelectedItem;
				string from = fromSelected.Content.ToString();

				RoomListAdminListBox.Items.Clear();
				List<IRoom> roomsList = VM.GetAvailableRooms(from, to, date);

				foreach (IRoom room in roomsList)
				{
					RoomListAdminListBox.Items.Add(room);
				}
			}
		}

		private void ToSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateRoomsList();
		}

		private void FromSelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateRoomsList();
		}

		private void DateChanged(object sender, SelectionChangedEventArgs e)
		{
			UpdateRoomsList();
		}
	}
}
