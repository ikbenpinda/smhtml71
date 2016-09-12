using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace formsapp2
{
	public partial class MyPage : ContentPage
	{
		ICamera camera;

		public MyPage()
		{
			InitializeComponent();

			camera = new DefaultCamera(this);

			takePictureButton.Clicked += (sender, e) =>
			{
				camera.takePicture();
			};

			takeVideoButton.Clicked += (sender, e) =>
			{
				camera.takeVideo();
			};
		}
	}
}

