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

namespace MessengerApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		private string login = "admin";
		private string password = "12345";
		public MainWindow()
		{
			InitializeComponent();
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			if(Login(login, password))
			{
				ChangeScreen(ContactsScreen);
			}
			else
			{
				LoginMessageBlock.Text = "Wrong login or password!";
				LoginMessageBlock.Visibility = Visibility.Visible;
			}
		}

		private bool Login(string login, string password)
		{
			if(LoginBox.Text == login && PasswordBox.Password == password)
			{
				return true;
			} 
			else
			{
				return false;
			}
		}

		private void ChangeScreen(Border screen)
		{
			LoginScreen.Visibility = Visibility.Hidden;
			ContactsScreen.Visibility = Visibility.Hidden;
			ChatScreen.Visibility = Visibility.Hidden;

			screen.Visibility = Visibility.Visible;
		}
	}
}
