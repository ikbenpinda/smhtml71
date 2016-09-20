using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;
using System.Collections.Generic;

namespace formsapp2
{
	public partial class HomePage : ContentPage
	{
		// todo Move repositories to Application class?
		// fixme get all data through user object or straight from repository/database? Syncing? Lazy loading?
		IUserRepository userRepository = new FakeUserRepository();
		ITravelogueRepository travelogueRepository = new FakeTravelogueRepository();
		//IMediaRepository mediaRepository = new FakeMediaRepository();

        MediaFile mediafile;
		User user;
		List<Travelogue> travelogues;

		public HomePage()
		{
			InitializeComponent();

			user = userRepository.load();

			lbl_greeting.FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label));
			lbl_greeting.FontAttributes = FontAttributes.Italic;
			lbl_greeting.HorizontalTextAlignment = TextAlignment.Center;
			lbl_greeting.Text = "Hello, " +  user.name + "!";
		}

		public async void btn_startTestPage(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new TestPage() { Title="Testpagina"});
		}
    }
}

