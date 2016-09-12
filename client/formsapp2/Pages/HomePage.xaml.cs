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
	public partial class HomePage : ContentPage
	{
		IUserRepository users = new FakeUserRepository();
        public MediaFile mediafile;
        public String username = "pietje";
		public HomePage()
		{
			InitializeComponent();

			var user = users.load();

			Title = "Home";
		}

		//public async void btn_openCamera(object sender, EventArgs e)
		//{
		//	await Navigation.PushModalAsync(new TestPage());
		//}

		public async void btn_startTestPage(object sender, EventArgs e)
		{
			await Navigation.PushModalAsync(new TestPage());
		}

  //      public async void btn_uploadImage(object sender, EventArgs e) {
  //          var file = await CrossMedia.Current.PickPhotoAsync();
  //          if (file == null)
  //              return;
  //          mediafile = file;
  //          try
  //          {

  //              HttpClient client = new HttpClient();
  //              client.BaseAddress = new Uri("http://145.93.114.154:8081");
  //              byte[] data = fileToByteArray(file);
  //              var fileContent = new ByteArrayContent(data);
  //              fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
  //              {
  //                  Name = "file",
  //                  FileName = "img"
  //              };
  //              fileContent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");
  //              var content = new MultipartFormDataContent();
  //              content.Add(fileContent);

  //              var result = client.PostAsync("/fileUpload", content).Result;
  //              Debug.WriteLine(result);
  //          }
  //          catch (Exception ex)
  //          {
  //              Debug.WriteLine(ex);
  //          }
    

  //      }
  //      public async void btn_uploadVideo(object sender, EventArgs e)
  //      {
  //          var file = await CrossMedia.Current.PickVideoAsync();
  //          if (file == null)
  //              return;

  //          byte[] data = fileToByteArray(file);
  //          var fileContent = new ByteArrayContent(data);
  //          fileContent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
  //          {
  //              Name = "file",
  //              FileName = "vid",




  //          };
  //          fileContent.Headers.ContentType = new MediaTypeHeaderValue("video/mp4");
  //          var content = new MultipartFormDataContent();
  //          content.Add(fileContent);
            
  //          HttpClient client = new HttpClient();
  //          client.BaseAddress = new Uri("http://145.93.114.154:8081");
  //          var result = client.PostAsync("/fileUpload", content).Result;
  //          Debug.WriteLine(result);
  //      }

  //      public byte[] fileToByteArray(MediaFile file)
  //      {
  //          using (var memoryStream = new MemoryStream())
  //          {
  //              file.GetStream().CopyTo(memoryStream);
  //              file.Dispose();
  //              return memoryStream.ToArray();
  //          }
  //      }
    }
}

