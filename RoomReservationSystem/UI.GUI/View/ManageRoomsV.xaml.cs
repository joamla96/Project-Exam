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
using Core;
using Core.Interfaces;

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
