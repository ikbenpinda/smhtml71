using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace formsapp2
{
	/// <summary>
	/// The hard way of using the camera.
	/// Seriously, just use DefaultCamera and be done with it.
	/// However, if you want the fancy custom camera view/'muh native',
	///  you need to use this + your platform-specific custom rendering.
	/// ...and then you need to actually capture the preview, 
	/// but that is currently not implemented, sorry!
	/// </summary>
	public class CameraPreview : View
	{

		public static readonly BindableProperty CameraProperty = BindableProperty.Create(
  		propertyName: "Camera",
  		returnType: typeof(CameraOptions),
  		declaringType: typeof(CameraPreview),
  		defaultValue: CameraOptions.Rear);

		public CameraOptions Camera
		{
			get { return (CameraOptions)GetValue(CameraProperty); }
			set { SetValue(CameraProperty, value); }
		}

		public CameraPreview() { }
	}

	public enum CameraOptions
	{
		Rear,
		Front
	}
}

