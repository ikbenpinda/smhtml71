using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using PCLStorage;
using Xamarin.Forms;

namespace formsapp2
{
	public class FakeMediaStorage : IStorage
	{
		public FakeMediaStorage() { 
			Debug.WriteLine("Warning: Using fake MediaStorage.");
		}

		public Media get(int id)
		{
			Debug.WriteLine("Loading image has not been implemented yet.");
			return null;
		}

		public async Task<List<Image>> getAllPictures()
		{
			Debug.WriteLine("LocalStorage path: " + FileSystem.Current.LocalStorage.Path);

			var pictures = "";
			var android = true;
			Device.OnPlatform(
				iOS: () => { pictures = "../Documents"; android = false; },
				Android: () => { pictures = "Pictures"; android = true; }
			);

			IFolder folder = null;

			if (android)
			{ 	// hack - PCLStorage and MediaPlugin don't play well together.
			  	// hack - Don't use Device.OnPlatform because of threading issues.
				// todo just get it from the server, fuck this.
				//await FileSystem.Current.LocalStorage.CreateFolderAsync("Pictures", CreationCollisionOption.OpenIfExists);
				Debug.WriteLine("STORAGEPATH: Searching...");

				try
				{
					folder = FileSystem.Current.GetFolderFromPathAsync("/storage/emulated/0/Android/data/com.companyname.formsapp2/files/Pictures").Result;		
					if (folder == null)
					{
						throw new Exception("folder is null.");
					}
				}
				catch (Exception ex)
				{
					Debug.WriteLine("EX: " + ex.Message);
					return new List<Image>();
				}
				//folder = await FileSystem.Current.LocalStorage.GetFolderAsync("Pictures");
			}
			else {
				Debug.WriteLine("STORAGEPATH: Searching...");
				folder = await FileSystem.Current.LocalStorage.GetFolderAsync(pictures);
			}
			
			//var file = await android_folder.GetFileAsync(filename);
			Debug.WriteLine("STORAGEPATH: " + folder);
			List<Image> images = new List<Image>();
			foreach (IFile file in await folder.GetFilesAsync())
			{
				Image image = new Image() { 
					Aspect = Aspect.AspectFit, 
					Source = file.Path
				};
				Debug.WriteLine("FILES: Added file: " + file.Path);
				images.Add(image);
			}

			return images;
		}

		public void save(Media media)
		{
			Debug.WriteLine("Saving media(" + media.title + ")...");
		}
	}
}

