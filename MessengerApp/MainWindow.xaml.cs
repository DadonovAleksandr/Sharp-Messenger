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
			MessagesList.ItemsSource = app.Chat;
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

				MessagesList.ItemsSource = app.Chat;
				ChatName.Text = app.CurrentContact.Name;

				Open(ChatScreen);
			}
			
		}

		private void SendButton_Click(object sender, RoutedEventArgs e)
		{

			string text = "";

			if(!string.IsNullOrEmpty(MessageBox.Text))
			{
				
				text = MessageBox.Text.Trim();
			}

			if(!string.IsNullOrEmpty(text))
			{
				User reciever;

				if (app.CurrentContact.Users[0].ID == app.User.ID)
				{
					reciever = app.CurrentContact.Users[0];
				}
				else
				{
					reciever = app.CurrentContact.Users[1];
				}

				Message message = new Message(text, app.User, reciever, app.User.ID);

				bool result = app.Send(message);

				if(result)
				{
					MessageBox.Text = "";
					app.Update();
				}
				
			}
			else
			{

			}

			
		}

		private void BackButton_Click(object sender, RoutedEventArgs e)
		{
			Open(ContactsScreen);
		}
	}
}
