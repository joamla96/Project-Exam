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

namespace UI.GUI.View
{
    /// <summary>
    /// Interaction logic for SeeMyReservationsV.xaml
    /// </summary>
    public partial class SeeMyReservationsV : Page
    {

        ReservationRepository reserveRepo = ReservationRepository.Instance;


        public SeeMyReservationsV()
        {
            InitializeComponent();

            //List<Reservation> reservationList = reserveRepo.Get(Core.LoggedIn.User);

            //foreach (Reservation reservation in reservationList)
            //{
            //    ReservationListListBox.Items.Add(reservation);
            //}


        }


    }
}
