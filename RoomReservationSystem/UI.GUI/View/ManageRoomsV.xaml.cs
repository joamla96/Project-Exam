using Core.Interfaces;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UI.GUI.ViewModel;

namespace UI.GUI.View
{
	/// <summary>
	/// Interaction logic for ManageRoomsV.xaml
	/// </summary>
	public partial class ManageRoomsV : Page
	{

		ManageRoomsVM VM = new ManageRoomsVM();

		public ManageRoomsV()
		{
			InitializeComponent();
			UpdateMyRoomListBox();
		}

		private void UpdateMyRoomListBox()
		{
			ManageRoomsListBox.Items.Clear();
			List<IRoom> roomList = VM.GetRoomList();

			foreach (IRoom room in roomList)
			{
				ManageRoomsListBox.Items.Add(room);
			}
		}

		private void DeleteSelectedRoom()
		{
			VM.DeleteRoom((IRoom)ManageRoomsListBox.SelectedItem);

		}

		private void ShowRoomListButtonClick(object sender, RoutedEventArgs e)
		{
			UpdateMyRoomListBox();
		}

		private void DeleteRoomButtonClick(object sender, RoutedEventArgs e)
		{
			DeleteSelectedRoom();
			UpdateMyRoomListBox();
		}

	}
}
