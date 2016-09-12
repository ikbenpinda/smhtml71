using System;
using System.Threading;
using System.Threading.Tasks;
using PCLStorage;

namespace formsapp2
{
	public class MediaStorage : IStorage
	{
		public const string PATH_APP_FOLDER = "/Chillgids";
		public const string PATH_USER_PREFS = "/user_prefs";
		public const string PATH_TRAVELOGUES = "/travelogues";
		public const string PATH_PHOTOS = "/photos";
		public const string PATH_VIDEOS = "/videos";
		public const string PATH_RECORDINGS = "/recordings";
		public const string PATH_NOTES = "/notes";

		public MediaStorage() { }

		public Media get(int id)
		{
			// todo check type
			// todo get folder
			// todo get by id
			throw new NotImplementedException();
		}

		public async void save(Media media)
		{
			getSubfolderForMedia(media);

			IFolder rootFolder = FileSystem.Current.LocalStorage;
			IFolder folder = await rootFolder.CreateFolderAsync(
				getSubfolderForMedia(media),
				CreationCollisionOption.OpenIfExists
			);
			IFile file = await folder.CreateFileAsync(
				media.title, // Should include a file extension, probably.
				CreationCollisionOption.ReplaceExisting
			);

		}

		/// <summary>
		/// Returns the full path to the local app folder.
		/// </summary>
		public async Task<string> getAppFolder()
		{
			IFolder rootFolder = FileSystem.Current.LocalStorage;
			ExistenceCheckResult result = rootFolder.CheckExistsAsync(PATH_APP_FOLDER).Result;
			if (result == ExistenceCheckResult.FileExists)
			{
				
			}
			IFolder folder = await rootFolder.CreateFolderAsync(
				PATH_APP_FOLDER,
				CreationCollisionOption.OpenIfExists
			);
			System.Diagnostics.Debug.WriteLine("Retrieving App folder(" + rootFolder.Path + ")");
			return rootFolder.Path;
		}

		/// <summary>
		/// Returns the full path to the folder containing the user preferences.
		/// </summary>
		/// <returns>The user prefs folder.</returns>
		public string getUserPrefsFolder()
		{
			string path = getAppFolder() + PATH_USER_PREFS;
			System.Diagnostics.Debug.WriteLine("Retrieving user_prefs folder(" + path + ")");
			return path;
		}

		/// <summary>
		/// Gets the full path to the travelogue directory.
		/// </summary>
		public string getTravelogueFolder(Travelogue travelogue)
		{
			string path = getAppFolder() + PATH_TRAVELOGUES;

			//hack / todo travelogue id!
			System.Diagnostics.Debug.WriteLine("Warning: travelogue id not implemented - ");
			System.Diagnostics.Debug.WriteLine("Warning: using test folder(travelogue_000)!");
			string travelogue_id = "travelogue_000 ";

			System.Diagnostics.Debug.WriteLine("Retrieving travelogue folder(" + path + ")");
			return path + travelogue_id;
		}

		/// <summary>
		/// Returns the full path to the subfolder for the related type of media."/> 
		/// </summary>
		public string getSubfolderForMedia(Media media)
		{
			string path = "";

			switch (media.type)
			{
				case Type.TEXT:
					path = PATH_NOTES;
					break;
				case Type.VIDEO:
					path = PATH_VIDEOS;
					break;
				case Type.AUDIO:
					path = PATH_RECORDINGS;
					break;
				case Type.PHOTO:
					path = PATH_PHOTOS;
					break;
				default:
					System.Diagnostics.Debug.WriteLine("Type " + media.type.ToString() + " not found! Something went wrong! :(");
					break;
			}

			return path;
			//e.g. app_folder/travelogues/travelogue_000/notes
			//return getTravelogueFolder(media.travelogue) + path;
		}

		/// <summary>
		/// Debug function for listing all created files and folders.
		/// </summary>
		public string ls()
		{
			return "not implemented yet.";
		}
	}
}

