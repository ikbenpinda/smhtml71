
using formsapp2.Code.api;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace formsapp2
{
    public partial class AddEntryPage : ContentPage
	{
		ICamera camera;
        Travelogue log;
        List<string> tableitems;
        LogEntry entry;

        public AddEntryPage(Travelogue travelogue)
		{
            camera = new DefaultCamera(this);
            InitializeComponent();
            entry = new LogEntry();
            tableitems = new List<string>();
            listview_media.ItemsSource = tableitems;
            listview_media.ItemTemplate = new DataTemplate(typeof(TextCell));
            listview_media.ItemTemplate.SetBinding(TextCell.TextProperty, ".");
            log = travelogue;
			
			Title = "Add Entry";
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
                    foreach (Media media in entry.getMedia().ToArray())
                    {
                        if (e.SelectedItem.ToString() == media.getTitle())
                        {
                            tableitems.Remove(media.getTitle());
                            entry.getMedia().Remove(media);

                        }
                    }
                listview_media.ItemsSource = null;
                listview_media.ItemsSource = tableitems;
                }

            };


        }
        /// <summary>
        /// pick a photo from the gallery or take a photo from camera, put the title in the list and convert the photo to base64(for webview)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Btn_addImageToEntry_Clicked(object sender, System.EventArgs e)
        {
            string galleryChoice = "Pick photo from gallery";
            string cameraChoice = "Make photo from camera";
            string videoChoice = "Pick video from gallery";
            string[] options = { galleryChoice, cameraChoice, videoChoice };
            var action = await DisplayActionSheet("Choose:", "Cancel", null, options);
            MediaFile file = null;
            string type = "";
            if (action == galleryChoice)
            {
                file = await CrossMedia.Current.PickPhotoAsync();
                if (file == null)
                    return;
                type = "img";
            }
            else if (action == cameraChoice)
            {
                if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
                {
                    await DisplayAlert("No Camera", ":( No camera available.", "OK");

                }

                file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
                {
                    Directory = "photos",
                    Name = "test.jpg"
                });
                type = "img";
                if (file == null)
                    return;
            }
            else if (action == videoChoice)
            {
                file = await CrossMedia.Current.PickVideoAsync();
                if (file == null)
                    return;

                type = "vid";
            }
            else { return; }

            int index = file.Path.LastIndexOf(@"/");
            string filename = file.Path.Substring(index + 1);

            byte[] data = fileToByteArray(file);
            string base64;
            if (type == "img")
            {
                byte[] resizedData = DependencyService.Get<IResizeImage>().ResizeImage(data, 300, 200);
                base64 = Convert.ToBase64String(resizedData);
            }
            else {
                base64 = Convert.ToBase64String(data);
            }

            Media media = new Media(filename, base64);
            media.setExt(type);
            entry.addAttachment(media);

            tableitems.Add(media.getTitle());

            listview_media.ItemsSource = null;
            listview_media.ItemsSource = tableitems;
        }
        /// <summary>
        /// add a new entry to the travelogue
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_addEntry_Clicked(object sender, System.EventArgs e)
        {
            entry.setTitle(entr_EntryTitle.Text);
            entry.setContent(entr_EntryContent.Text);
            log.addNewEntry(entry);
            Navigation.PopAsync();
        }

        /// <summary>
        /// convert an MediaFile to byes[]
        /// </summary>
        /// <param name="file"></param>
        /// <returns></returns>
        public byte[] fileToByteArray(MediaFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.GetStream().CopyTo(memoryStream);
                file.Dispose();
                return memoryStream.ToArray();
            }
        }
    }
}

