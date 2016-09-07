using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace formsapp2
{
	public partial class HomePage : ContentPage
	{
		IUserRepository users = new FakeUserRepository();

		public HomePage()
		{
			InitializeComponent();

			var user = users.load();

			Title = "Home";
			greetingLabel.Text = "Hello, " + user.name + "!";
		}
	}
}

