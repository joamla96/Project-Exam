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
using Core;

namespace UI.GUI.View {
	/// <summary>
	/// Interaction logic for User.xaml
	/// </summary>
	public partial class User : Window {
		public User() {
			Permission permissionLevel = LoggedIn.User.PermissionLevel;
			InitializeComponent();

			if (permissionLevel == Permission.Student) {
				ManageRoomsButton.Visibility = Visibility.Hidden;
				ManageReservationsButton.Visibility = Visibility.Hidden;
			}

			if (permissionLevel == Permission.Teacher) {
				ManageRoomsButton.Visibility = Visibility.Hidden;
				ManageReservationsButton.Visibility = Visibility.Hidden;
			}

			if (permissionLevel == Permission.Admin) {
				ReserveRoomButton.Visibility = Visibility.Hidden;
				SeeMyReservationButton.Visibility = Visibility.Hidden;
			}
		}


		private void ReserveRoomButtonClick(object sender, RoutedEventArgs e) {
			Frame.Content = new ReserveRoom();
		}

		private void SeeMyReservationButtonClick(object sender, RoutedEventArgs e) {
			Frame.Content = new SeeMyReservationsV();

		}

		private void ManageRoomsButtonClick(object sender, RoutedEventArgs e) {
			Frame.Content = new ManageRoomsV();
		}

		private void ManageReservationsButtonClick(object sender, RoutedEventArgs e) {
			Frame.Content = new ManageReservationsV();
		}
	}
}
