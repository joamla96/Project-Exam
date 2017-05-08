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
    /// Interaction logic for ReserveRoom.xaml
    /// </summary>
    public partial class ReserveRoom : Page
    {
        public ReserveRoom()
        {
            InitializeComponent();
        }
        private void ReserveRoomButtonClick(object sender, RoutedEventArgs e)
        {
            string date = SelectDate.Text;
            string to = (string)ToListBox.Content;
            string from = (string)FromListBox.Content;
            string peopleNr = NumberOfPeopleTextBox.Text;

            if (peopleNr == "")
            {
                MessageLabel.Content = "Enter number of people! ";
            }
            else
            {
                ViewModel.ReserveRoomVM reserveRoom = new ViewModel.ReserveRoomVM();
                MessageLabel.Content = reserveRoom.ReserveRoom(date, from, to, peopleNr);
            }
        }
    }
}
