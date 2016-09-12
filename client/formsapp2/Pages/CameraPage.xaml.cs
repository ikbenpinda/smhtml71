using System;
using System.Collections.Generic;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace formsapp2
{
	/// <summary>
	/// Wrapper page for CameraView.
	/// </summary>
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

