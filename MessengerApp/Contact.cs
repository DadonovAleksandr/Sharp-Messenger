using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerApp
{
	class Contact
	{
		private User[] users;

		public Contact(User u1, User u2)
		{
			users = new User[] { u1, u2 };
		}

		public User[] Users
		{
			get
			{
				return users;
			}
		}
	}
}
