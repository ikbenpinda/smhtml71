using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace formsapp2
{
	public partial class TraveloguePage : ContentPage
	{
        List<Travelogue> listLog = new List<Travelogue>();
        Travelogue selectedLog;
        List<string> tableItems = new List<string>();
        public TraveloguePage()
        {
            //-----------TEST DATA-------------------------------------------
            Travelogue test = new Travelogue("test");
            Travelogue test1 = new Travelogue("LifeOfPietje");
            test1.addNewEntry(new formsapp2.Entry("Day one", "Lorem ipsum dolor sit amet, consectetur adipiscing elit.In hendrerit risus eget leo commodo, in tempus nisi suscipit.Integer odio ante, consequat eget molestie at, lobortis vel dolor.Vivamus bibendum urna ac est cursus euismod.Sed aliquam ante quis massa rutrum laoreet.Vivamus elementum interdum lacus at semper.Vivamus eleifend quis est sit amet elementum.Etiam justo enim, interdum vel ipsum nec, maximus molestie odio. "));
            test1.addNewEntry(new formsapp2.Entry("Graduation", "Sed non metus vel orci fermentum venenatis. Morbi nunc turpis, volutpat mattis lacus sit amet, accumsan semper magna. Proin quis commodo risus, eu gravida lacus. In hendrerit volutpat ante. Cras lacinia elit sit amet sodales tempus. Aenean non justo in ipsum aliquet luctus vel id velit. Vestibulum nec semper enim. "));
            test1.addNewEntry(new formsapp2.Entry("Holidays over", "Phasellus scelerisque libero quis nibh sodales tincidunt. Vestibulum et gravida nisl. Proin eu sagittis mi, eu malesuada leo. Curabitur porta lorem sem, vel rutrum nibh aliquam ac. Fusce feugiat justo sit amet eleifend laoreet. Nam quis vehicula ligula, congue pulvinar leo. Mauris et pretium sapien, in semper felis. Fusce efficitur interdum nisl id vulputate. "));
            //----------------------------------------------------------------

            this.listLog.Add(test);
            this.listLog.Add(test1);
            tableItems.Add(test.ToString());
            tableItems.Add(test1.ToString());

            var list = new ListView();
            list.ItemsSource = tableItems;
            list.ItemTemplate = new DataTemplate(typeof(TextCell));
            list.ItemTemplate.SetBinding(TextCell.TextProperty, ".");
            list.ItemSelected += async (sender, e) => {
                int index = tableItems.IndexOf((string)e.SelectedItem);
                if (index >= 0)
                {
                    selectedLog = listLog[index];
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
            if (tableItems.Count != 0)
            {
                var action = await DisplayActionSheet("Remove:", "Cancel", null, tableItems.ToArray());
            }
        }

        public void Btn_add_Clicked(object sender, EventArgs e)
		{
			Navigation.PushAsync(new AddTraveloguePage());
		}
	}
}

