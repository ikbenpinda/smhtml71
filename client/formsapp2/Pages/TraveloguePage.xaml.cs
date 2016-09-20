using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace formsapp2
{
    public partial class TraveloguePage : ContentPage
    {
        Travelogue selectedLog;
        FakeTravelogueRepository fakeTravel;
        ListView list;
        public TraveloguePage()
        {
            fakeTravel = FakeTravelogueRepository.Instance;
            list = new ListView();
            list.ItemsSource = fakeTravel.getTableItems();
            list.ItemTemplate = new DataTemplate(typeof(TextCell));
            list.ItemTemplate.SetBinding(TextCell.TextProperty, ".");
            list.ItemSelected += async (sender, e) =>
            {
                int index = fakeTravel.getTableItems().IndexOf((string)e.SelectedItem);
                if (index >= 0)
                {
                    selectedLog = fakeTravel.getTravelList()[index];
                }
                Debug.WriteLine("index:" + index);
                if (e.SelectedItem == null)
                    return;
                await Navigation.PushAsync(new TravelogueDetailPage(selectedLog));
                list.SelectedItem = null;
            };
            Button btn_add = new Button
            {
                Text = "Add new travelogue"
            };
            Button btn_remove = new Button
            {
                Text = "Remove travelogue"
            };
            btn_remove.Clicked += Btn_remove_Clicked;
            btn_add.Clicked += Btn_add_Clicked;
            Content = new StackLayout
            {
                Padding = new Thickness(5, Device.OnPlatform(20, 0, 0), 5, 0),
                Children = {
                    new Label {
                        HorizontalTextAlignment = TextAlignment.Center,
                        Text = "List of travelogues"
                    },
                    list,
                    btn_add,
                    btn_remove
                }
            };
            InitializeComponent();

            this.Title = "Log";
        }

        private async void Btn_remove_Clicked(object sender, System.EventArgs e)
        {
            if (fakeTravel.getTableItems().Count != 0)
            {
                var action = await DisplayActionSheet("Remove:", "Cancel", null, fakeTravel.getTableItems().ToArray());
                foreach (Travelogue log in fakeTravel.getTravelList().ToArray())
                {
                    if (action == log.ToString())
                    {
                        fakeTravel.removeTravelogue(log);
                        list.ItemsSource = fakeTravel.getTableItems();
                    }
                }
            }
        }

        public void Btn_add_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddTraveloguePage());
        }

        protected override void OnAppearing() {
            list.ItemsSource = fakeTravel.getTableItems();
        }
    }
}

