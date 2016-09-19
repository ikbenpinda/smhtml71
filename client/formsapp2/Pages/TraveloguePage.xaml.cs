using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace formsapp2
{
	public partial class TraveloguePage : ContentPage
	{
		ITravelogueRepository travelogueRepository;
		List<Travelogue> logs;

		public TraveloguePage()
		{
			InitializeComponent();
			this.Title = "Log";

			travelogueRepository = new FakeTravelogueRepository();
			logs = travelogueRepository.getAll();

			bool logsAvailable = logs.Count > 0;
			if (logsAvailable)
			{
				lv_Travelogues.ItemsSource = logs;
				lbl_NoLogsAvailable.IsVisible = false;
			}
			else
			{
				lv_Travelogues.IsVisible = false;
				lbl_NoLogsAvailable.IsVisible = true;
			}

			lv_Travelogues.ItemSelected += (sender, e) => OnTravelogueSelected(sender, e);
		}

		public async void OnTravelogueSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var selected = (Travelogue) e.SelectedItem;

			if (selected == null) // Happens on deselecting.
				return;

			Debug.WriteLine("Clicked item: " + selected);

			// ModalAsync could be used here as well, but this allows for easier navigation/editing while travelling.
			await Navigation.PushAsync(new TravelogueDetailPage() { Title = selected.name });

			((ListView)sender).SelectedItem = null;
		}

		public void btn_CreateNewTravelogue(object sender, EventArgs e)
		{
			Navigation.PushAsync(new AddTraveloguePage());
		}
	}
}

