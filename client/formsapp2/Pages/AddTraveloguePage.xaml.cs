using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace formsapp2
{
    public partial class AddTraveloguePage : ContentPage
    {
        Entry entry;
        FakeTravelogueRepository fakeTravel;
        public AddTraveloguePage()
        {
            fakeTravel = FakeTravelogueRepository.Instance;
            Title = "Create new travelogue";
            InitializeComponent();
            Label label = new Label { Text = "Title: " };
            entry = new Entry();
            entry.VerticalOptions = LayoutOptions.FillAndExpand;
            entry.HorizontalOptions = LayoutOptions.FillAndExpand;
            Button btn_add = new Button { Text = "Add" };
            Button btn_cancel = new Button { Text = "Cancel" };
            btn_add.Clicked += Btn_add_Clicked;
            btn_cancel.Clicked += Btn_cancel_Clicked;
            Content = new StackLayout
            {
                Children = {
                    label,
                    entry,
                    btn_add,
                    btn_cancel
                }
            };
         } 

        private void Btn_add_Clicked(object sender, EventArgs e)
        {
            fakeTravel.addTravelogue(new Travelogue(entry.Text));
            Navigation.PopAsync();
        }

        private void Btn_cancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}

