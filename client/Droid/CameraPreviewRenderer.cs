using System;
using Android.Content;
using Android.Hardware;
using Android.Provider;
using CustomRenderer.Droid;
using formsapp2;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(formsapp2.CameraPreview), typeof(CameraPreviewRenderer))]
namespace CustomRenderer.Droid
{
	public class CameraPreviewRenderer : ViewRenderer<formsapp2.CameraPreview, CameraPreview>
	{
		CameraPreview cameraPreview;

		protected override void OnElementChanged(ElementChangedEventArgs<formsapp2.CameraPreview> e)
		{
			base.OnElementChanged(e);

			if (Control == null)
			{
				cameraPreview = new CameraPreview(Context);
				SetNativeControl(cameraPreview);
			}

			if (e.OldElement != null)
			{
				// Unsubscribe
				cameraPreview.Click -= OnCameraPreviewClicked;
			}

			if (e.NewElement != null)
			{
				Control.Preview = Camera.Open((int)e.NewElement.Camera);

				// Subscribe
				cameraPreview.Click += OnCameraPreviewClicked;
			}
		}

		void OnCameraPreviewClicked(object sender, EventArgs e)
		{
			if (cameraPreview.IsPreviewing)
			{
				cameraPreview.Preview.StopPreview();
				cameraPreview.IsPreviewing = false;
			}
			else {
				cameraPreview.Preview.StartPreview();
				cameraPreview.IsPreviewing = true;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				Control.Preview.Release();
			}
			base.Dispose(disposing);
		}
	}
}