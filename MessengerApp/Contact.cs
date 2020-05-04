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

		public bool Confirm(User u1, User u2)
		{
			if((u1.ID == users[0].ID && u2.ID == users[1].ID) || (u1.ID == users[1].ID && u2.ID == users[0].ID))
			{
				return true;
			}
			else
			{
				return false;
			}
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
