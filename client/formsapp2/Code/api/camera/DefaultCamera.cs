using System;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace formsapp2
{
	public class DefaultCamera : ICamera
	{
		IStorage storage;
		Page page;

		public DefaultCamera(Page page)
		{
			this.page = page;
			storage = new FakeMediaStorage();
		}

		/// <summary>
		/// Takes the picture and saves it to the local storage.
		/// </summary>
		/// <returns>The picture.</returns>
		public async Task<Image> takePicture() // todo async event / return types
		{
			Image image = new Image();

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
			{
				page.DisplayAlert("No Camera", ":( No camera available.", "OK");
				return null;
			}

			var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
			{
				Directory = "photos",
				Name = "test.jpg"
			});

			if (file == null)
				return null;

			page.DisplayAlert("File Location", file.Path, "OK");

			image.Source = ImageSource.FromStream(() =>
			  {
				  var stream = file.GetStream();
				  file.Dispose();
				  return stream;
			  });

			return image;
		}


        /// <summary>
        /// Takes the video and stores it in the local storage.
        /// </summary>
        /// <returns>The video.</returns>
        public async Task<MediaFile> takeVideo(){

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
			{
				page.DisplayAlert("No Camera", ":( No camera available.", "OK");
				return null;
			}

			var file = await CrossMedia.Current.TakeVideoAsync(
				new StoreVideoOptions{
					Directory = "videos",
					Name = "vid.mp4" // Automatically numbered/suffixed with "_[id]".
			});

			if (file == null)
				return null;

			page.DisplayAlert("File Location", file.Path, "OK");

			file.Dispose();

			return file;
		}
	}
}

