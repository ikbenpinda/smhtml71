using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace formsapp2
{
	public partial class AddEntryModalPage : ContentPage
	{
		ICamera camera;

		public AddEntryModalPage()
		{
			InitializeComponent();
			Title = "Add Entry";
			camera = new DefaultCamera(this);

			btn_addImageToEntry.Clicked += (sender, e) => camera.takePicture();
			btn_addVideoToEntry.Clicked += (sender, e) => camera.takeVideo();
		}
	}
}

