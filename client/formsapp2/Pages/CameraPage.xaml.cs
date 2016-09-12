using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace formsapp2
{
	public partial class CameraPage : ContentPage
	{
		ICamera camera;

		public CameraPage()
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

