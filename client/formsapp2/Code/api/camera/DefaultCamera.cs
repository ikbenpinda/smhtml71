using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ModernHttpClient;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace formsapp2
{
	public class DefaultCamera : ICamera
	{
		public const string DELIMITER = "__";

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

			long id = Time.getUnixTimestamp(); // hack
			var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
			{
				Name = "img" + id +".jpg",
				SaveToAlbum = false
			});

			if (file == null)
				return null;

			page.DisplayAlert("foto opgeslagen: ", file.Path, "OK");

			image.Source = ImageSource.FromStream(() =>
			  {
				  var stream = file.GetStream();
				  file.Dispose();
				  return stream;
			  });

			UploadPicture(file);

			return image;
		}


        /// <summary>
        /// Takes the video and stores it in the local storage.
        /// </summary>
        /// <returns>The video.</returns>
        public async Task<MediaFile> takeVideo(){

			if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
			{
				//page.DisplayAlert("No Camera", ":( No camera available.", "OK");
				return null;
			}

			var id = Time.getUnixTimestamp();
			var file = await CrossMedia.Current.TakeVideoAsync(
				new StoreVideoOptions{
					Name = "vid" + id + ".mp4", // Automatically numbered/suffixed with "_[id]".
					SaveToAlbum = false,
			});

			if (file == null)
				return null;

			page.DisplayAlert("video opgeslagen: ", file.Path, "OK");

			file.Dispose();

			return file;
		}

		string baseurl = "http://145.93.114.157:8081";
		IUserRepository user_db = new FakeUserRepository();

		public void UploadPicture(MediaFile file)
		{
			var user = user_db.load();

			var path = file.Path;
			Debug.WriteLine("PATH: " + path);

			int index = file.Path.LastIndexOf(@"/");
			Debug.WriteLine("INDEX: " + index);

			var fn = file.Path.Substring(index + 1);
			Debug.WriteLine("FILENAME: " + fn);

			if (file == null)
				return;
			
			try
			{
				HttpClient client = new HttpClient(new NativeMessageHandler());
				client.BaseAddress = new Uri(baseurl);
				byte[] data = fileToByteArray(file);
				var fileContent = new ByteArrayContent(data);
				fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
				{
					Name = "file",
					FileName = user.name + DELIMITER + fn
				};
				Debug.WriteLine("UPLOADING: " + fileContent.Headers.ContentDisposition.FileName);
				fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
				var content = new MultipartFormDataContent();
				content.Add(fileContent);

				var result = client.PostAsync("/fileUpload", content).Result;
				Debug.WriteLine(result);
			}
			catch (Exception ex)
			{
				Debug.WriteLine(ex);
			}
		}

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

