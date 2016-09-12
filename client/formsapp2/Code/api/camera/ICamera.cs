using System;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;
using Xamarin.Forms;

namespace formsapp2
{
	/// <summary>
	/// Interface for handling the camera. 
	/// Implementation details belong to the implementation classes.
	/// Tasks are returned because most of these are async methods due to the hardware layer/performance.
	/// </summary>
	public interface ICamera
	{
		Task<Image> takePicture();
		Task<MediaFile> takeVideo();
	}
}

