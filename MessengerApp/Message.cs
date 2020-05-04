using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace MessengerApp
{
	class Message
	{
		private string text;
		private User sender;
		private User reciever;
		private Dock dock;
		private DateTime date;

		public Message(string text, User sender, User reciever, int id)
		{
			this.text = text;
			this.sender = sender;
			this.reciever = reciever;

			if(id == sender.ID)
			{
				dock = Dock.Right;
			}
			else
			{
				dock = Dock.Left;
			}

			date = new DateTime();
		}

		public string Text
		{
			get
			{
				return this.text;
			}
		}

		public string Date
		{
			get 
			{
				return $"{date.Day}.{date.Month}.{date.Year}";
			}
		}

		public Dock Dock
		{
			get
			{
				return this.dock;
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
