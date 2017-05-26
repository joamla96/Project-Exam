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

namespace UI.GUI.View
{
	/// <summary>
	/// Interaction logic for RegisterRoom.xaml
	/// </summary>
	public partial class RegisterRoom : Page
	{
		public RegisterRoom()
		{
			InitializeComponent();
		}

		private void RegisterRoomPageButtonClick(object sender, RoutedEventArgs e)
		{
			string building = BuildingTextBox.Text;
			string floor = FloorTextBox.Text;
			string nr = RoomNrTextBox.Text;
			string maxPeople = MaxPeopleNrTextBox.Text;
			ComboBoxItem minPermissionLevelSelected = (ComboBoxItem)MinPermissionLevelComboBox.SelectedItem;
			string minPermissionLevel = minPermissionLevelSelected.Tag.ToString();

			if (building == "" || floor == "" || nr == "" || maxPeople == "" || minPermissionLevel == "")
			{
				string fillInFieldsMessage = "Please fill in all the fields !";
				MessageBox.Show(fillInFieldsMessage);
			}
			else
			{
				ViewModel.RegisterRoomVM registerRoom = new ViewModel.RegisterRoomVM();

				registerRoom.RegisterRoom(building,floor,nr,maxPeople,minPermissionLevel);

				string registerRoomMessage = "Your room has been successfully registered !";
				MessageBox.Show(registerRoomMessage);
			}

			BuildingTextBox.Clear();
			FloorTextBox.Clear();
			RoomNrTextBox.Clear();
			MaxPeopleNrTextBox.Clear();
			

		}
	}
}
