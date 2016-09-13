using ModernHttpClient;
using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using Xamarin.Forms;

namespace formsapp2
{
	public partial class TestPage : ContentPage
	{
		IUserRepository users = new FakeUserRepository();
		public string username = "pietje";
        string baseurl = "http://145.93.114.152:8081";

        public TestPage()
		{
			InitializeComponent();

			var user = users.load();

			Title = "Home";
		}

		public async void btn_openCamera(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new CameraPage());
		}

		public async void btn_uploadImage(object sender, EventArgs e)
		{
			var file = await CrossMedia.Current.PickPhotoAsync();
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
					FileName = username+"_img"
				};
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
		public async void btn_uploadVideo(object sender, EventArgs e)
		{
			var file = await CrossMedia.Current.PickVideoAsync();
			if (file == null)
				return;
            byte[] data = fileToByteArray(file);
			var fileContent = new ByteArrayContent(data);
			fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
			{
				Name = "file",
				FileName =  username+"_vid"
			};
			fileContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
			var content = new MultipartFormDataContent();
			content.Add(fileContent);

			HttpClient client = new HttpClient(new NativeMessageHandler());
            client.BaseAddress = new Uri(baseurl);
			var result = client.PostAsync("/fileUpload", content).Result;
			Debug.WriteLine(result);
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

