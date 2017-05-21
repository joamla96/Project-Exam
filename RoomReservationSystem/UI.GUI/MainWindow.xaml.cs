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

namespace UI.GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow() {
			InitializeComponent();
			Initialize.StartUp();
		}

        private void AdminButtonClick(object sender, RoutedEventArgs e)
        {
			LoggedIn.User = new User("admin", "@eal.dk", Permission.Admin);
			View.User user = new View.User();
			user.Show();
		}

        private void StudentButtonClick(object sender, RoutedEventArgs e)
        {
			LoggedIn.User = new User("student", "@edu.eal.dk", Permission.Student);
			View.User user = new View.User();
            user.Show();  
        }

        private void TeacherButtonClick(object sender, RoutedEventArgs e)
        {
			LoggedIn.User = new User("teacher", "@eal.dk", Permission.Teacher);
			View.User user = new View.User();
			user.Show();
		}
    }
}
