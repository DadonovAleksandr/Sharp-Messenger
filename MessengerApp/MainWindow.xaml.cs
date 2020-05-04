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
		private Messenger app;

		public MainWindow()
		{
			InitializeComponent();

			app = new Messenger();

			ContactsList.ItemsSource = app.Contacts;
		}

		private void LoginButton_Click(object sender, RoutedEventArgs e)
		{
			if(app.Login(LoginBox.Text, PasswordBox.Password))
			{
				Open(ContactsScreen);
			}
			else
			{
				LoginMessageBlock.Text = "Wrong login or password!";
				LoginMessageBlock.Visibility = Visibility.Visible;
			}
		}

		private void Open(Border screen)
		{
			LoginScreen.Visibility = Visibility.Hidden;
			ContactsScreen.Visibility = Visibility.Hidden;
			ChatScreen.Visibility = Visibility.Hidden;

			//ContactsList.DataContext = app.Contacts;

			screen.Visibility = Visibility.Visible;
		}

		private void ContactsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if(ContactsList.SelectedIndex >= 0)
			{
				app.ChangeContact(ContactsList.SelectedIndex);
				ContactsList.SelectedIndex = -1;

				app.LoadChat();
				Open(ChatScreen);
			}
			
		}
	}
}
