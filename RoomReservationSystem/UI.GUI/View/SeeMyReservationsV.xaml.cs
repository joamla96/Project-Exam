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
using Core;
using UI.GUI.ViewModel;

namespace UI.GUI.View
{
	/// <summary>
	/// Interaction logic for SeeMyReservationsV.xaml
	/// </summary>
	public partial class SeeMyReservationsV : Page
	{
		DeleteReservationVM VM = new DeleteReservationVM();

		public SeeMyReservationsV()
		{
			InitializeComponent();

			UpdateMyReservationListBox();
		}

		private void UpdateMyReservationListBox()
		{
			ReservationListListBox.Items.Clear();
			List<Reservation> reservationList = VM.GetReservationList();

			foreach (Reservation reservation in reservationList)
			{
				ReservationListListBox.Items.Add(reservation);
			}
		}

		private void DeleteReservationButtonClick(object sender, RoutedEventArgs e)
		{
			DeleteReservationVM VM = new DeleteReservationVM();
			Reservation reservation = (Reservation)ReservationListListBox.SelectedItem;
			VM.DeleteReservation(reservation);
			UpdateMyReservationListBox();

			string deleteMessage = "Your reservation has been successfully deleted !";
			MessageBox.Show(deleteMessage);
		}
	}
}
