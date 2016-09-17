using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;

namespace formsapp2
{
	public partial class HomePage : ContentPage
	{
		IUserRepository users = new FakeUserRepository();
        public MediaFile mediafile;
		User user;

		public HomePage()
		{
			InitializeComponent();

			user = users.load();
			lbl_greeting.Text = "Hello, " +  user.name + "!";
		}

		public async void btn_startTestPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TestPage() { Title="Testpagina"});
		}
    }
}

