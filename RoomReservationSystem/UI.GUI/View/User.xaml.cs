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

namespace UI.GUI.View
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            Permission permissionLevel = LoggedIn.User.PermissionLevel;
            InitializeComponent();
            
           
        }

        
        private void ReserveProjectRoomButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Content = new ReserveRoom();
        }

        private void SeeMyReservationButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Content = new SeeMyReservationsV();
            
        }

        private void ReserveMeetingRoomButtonClick(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
