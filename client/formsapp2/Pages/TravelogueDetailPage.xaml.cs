using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace formsapp2
{
	public partial class TravelogueDetailPage : ContentPage
	{
		ITravelogueRepository travelogueRepository;

		public TravelogueDetailPage()
		{
			InitializeComponent();

			travelogueRepository = new FakeTravelogueRepository();

			var entries = travelogueRepository.getAll()[0].Entries;

			btn_addEntry.Clicked += (sender, e) => { Navigation.PushAsync(new AddEntryModalPage()); };
			lv_travelogueDetails.ItemSelected += (sender, e) => { ((ListView)sender).SelectedItem = null; };

			bool entriesAvailable = entries.Count > 0;
			if (entriesAvailable)
			{
				lbl_noEntriesAvailable.IsVisible = false;
				lv_travelogueDetails.IsVisible = true;
			}
			else 
			{
				lbl_noEntriesAvailable.IsVisible = true;
				lv_travelogueDetails.IsVisible = false;
			}

			// show details for item selected from previous page.
			lv_travelogueDetails.ItemsSource = entries; // todo templates! - last time data binding killed this project, so be careful!
		}
	}
}

