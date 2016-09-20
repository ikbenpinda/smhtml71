
using Plugin.Media;
using System.Collections.Generic;
using Xamarin.Forms;

namespace formsapp2
{
    public partial class AddEntryPage : ContentPage
	{
		ICamera camera;
        Travelogue log;
        List<string> tableitems;
		public AddEntryPage(Travelogue travelogue)
		{
            InitializeComponent();
            tableitems = new List<string>();
            listview_media.ItemsSource = tableitems;
            listview_media.ItemTemplate = new DataTemplate(typeof(TextCell));
            listview_media.ItemTemplate.SetBinding(TextCell.TextProperty, ".");
            log = travelogue;
			
			Title = "Add Entry";
			camera = new DefaultCamera(this);
            btn_addImageToEntry.Clicked += Btn_addImageToEntry_Clicked;
            btn_addEntry.Clicked += Btn_addEntry_Clicked;
            entr_EntryTitle.Placeholder = "Put title here";
            listview_media.ItemSelected += async (sender, e) =>
            {
               var answer =  await this.DisplayAlert("Delete", "Remove this attachment?", "Yes", "No");
                if (!answer)
                    return;
                else
                {
                    foreach (string media in tableitems.ToArray())
                    {
                        if (e.SelectedItem.ToString() == media)
                        {
                            tableitems.Remove(media);
                        }
                    }
                listview_media.ItemsSource = null;
                listview_media.ItemsSource = tableitems;
                }

            };


        }

        private async void Btn_addImageToEntry_Clicked(object sender, System.EventArgs e)
        {
            var file = await CrossMedia.Current.PickPhotoAsync();
            if (file == null)
                return;
            int index = file.Path.LastIndexOf(@"/");
            string filename = file.Path.Substring(index + 1);
            tableitems.Add(filename);
            listview_media.ItemsSource = null;
            listview_media.ItemsSource = tableitems;
        }

        private void Btn_addEntry_Clicked(object sender, System.EventArgs e)
        {
            log.addNewEntry(new LogEntry(entr_EntryTitle.Text, entr_EntryContent.Text));
            Navigation.PopAsync();
        }
    }
}

