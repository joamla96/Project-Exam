using System.Windows;
using Core;
using Core.Interfaces;
using System;

namespace UI.GUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		UserRepository _repoUser = UserRepository.Instance;

		public MainWindow()
		{
			InitializeComponent();
			Initialize.StartUp();
		}

		private void AdminButtonClick(object sender, RoutedEventArgs e)
		{
			IUser User = new User("admin", "admin@eal.dk", Permission.Admin);
			IUser AUser;

			try { AUser = _repoUser.Get(User); }
			catch (IndexOutOfRangeException) { _repoUser.Add(User); AUser = User; }
			LoggedIn.User = AUser;

			View.User user = new View.User();
			user.Show();
		}

		private void StudentButtonClick(object sender, RoutedEventArgs e)
		{
			IUser User = new User("student", "student@edu.eal.dk", Permission.Student);
			IUser AUser;

			try { AUser = _repoUser.Get(User); }
			catch (IndexOutOfRangeException) { _repoUser.Add(User); AUser = User; }
			LoggedIn.User = AUser;

			View.User user = new View.User();
			user.Show();
		}

		private void TeacherButtonClick(object sender, RoutedEventArgs e)
		{
			IUser User = new User("teacher", "teacher@eal.dk", Permission.Teacher);
			IUser AUser;

			try { AUser = _repoUser.Get(User); }
			catch (IndexOutOfRangeException) { _repoUser.Add(User); AUser = User; }
			LoggedIn.User = AUser;

			View.User user = new View.User();
			user.Show();
		}
	}
}
