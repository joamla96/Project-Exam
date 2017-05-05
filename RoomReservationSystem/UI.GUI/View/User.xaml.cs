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

namespace UI.GUI.View
{
    /// <summary>
    /// Interaction logic for User.xaml
    /// </summary>
    public partial class User : Window
    {
        public User()
        {
            InitializeComponent();
            
        }

        
        private void ReserveProjectRoomButtonClick(object sender, RoutedEventArgs e)
        {
            Frame.Content = new ReserveRoom();
        }

        private void SeeMyReservationButtonClick(object sender, RoutedEventArgs e)
        {

        }

        private void ReserveMeetingRoomButtonClick(object sender, RoutedEventArgs e)
        {

        }

        
    }
}
