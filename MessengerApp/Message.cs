using System;
using System.Collections.Generic;
using System.Text;

namespace MessengerApp
{
	class Message
	{
		private string text;
		private User sender;
		private User reciever;

		public Message(string text, User sender, User reciever)
		{
			this.text = text;
			this.sender = sender;
			this.reciever = reciever;
		}

		public string Text
		{
			get
			{
				return this.text;
			}
		}

		public User Sender
		{
			get
			{
				return this.sender;
			}
		}

		public User Reciever
		{
			get
			{
				return this.reciever;
			}
		}
	}
}
