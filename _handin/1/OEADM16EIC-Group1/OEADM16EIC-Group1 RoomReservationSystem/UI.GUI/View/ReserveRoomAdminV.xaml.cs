using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UI.GUI.ViewModel;

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

		private void ReserveRoomAdminPageButtonClick(object sender, RoutedEventArgs e)
		{
			string date = DateAdminDatePicker.Text;
			ComboBoxItem toSelected = (ComboBoxItem)ToAdminComboBox.SelectedItem;
			string to = toSelected.Content.ToString();
			ComboBoxItem fromSelected = (ComboBoxItem)FromAdminComboBox.SelectedItem;
			string from = fromSelected.Content.ToString();
			string username = UsernameAdminTextBox.Text;
			IRoom room = (IRoom)RoomListAdminListBox.SelectedItem;

			string message;
			try
			{
				VM.ReserveRoom(date, from, to, room, username);
				UpdateRoomsList();

				message = "Reservation successful!";
				
			}
			catch (IndexOutOfRangeException)
			{
				message = "Invalid username!";
			}
			MessageBox.Show(message);
		}
	}
}
