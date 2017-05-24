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

namespace UI.GUI.View {
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

		}
	}
}
