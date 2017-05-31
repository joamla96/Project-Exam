using Core;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using UI.GUI.ViewModel;

namespace UI.GUI.View
{
	/// <summary>
	/// Interaction logic for ManageReservationsV.xaml
	/// </summary>
	public partial class ManageReservationsV : Page {
		public ManageReservationsV() {
			InitializeComponent();
			UpdateReservationList();
		}

		ManageReservationsVM VM = new ManageReservationsVM();

		public void UpdateReservationList()
		{
			string fromDate = ManageResFromDatePicker.Text;
			string toDate = ManageResToDatePicker.Text;
			string searchUser = ManageResSearchTextBox.Text;

			ManageResListBox.Items.Clear();
			List<Reservation> reservationList = VM.GetReservations(fromDate, toDate, searchUser);

			foreach (Reservation reservation in reservationList)
			{
				ManageResListBox.Items.Add(reservation);
			}
		}

		private void DeleteReservationAdminButtonClick(object sender, RoutedEventArgs e)
		{
			Reservation reservation = (Reservation)ManageResListBox.SelectedItem;
			VM.DeleteReservation(reservation);
			UpdateReservationList();

			string message = "Reservation deleted successfully!";
			MessageBox.Show(message);
		}

		private void FromChangedDatePicker(object sender, RoutedEventArgs e)
		{
			UpdateReservationList();
		}

		private void ToChangedDatePicker(object sender, RoutedEventArgs e)
		{
			UpdateReservationList();
		}

		private void UsernameChangedTextBox(object sender, RoutedEventArgs e)
		{
			UpdateReservationList();
		}


	}
}
