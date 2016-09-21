using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace formsapp2
{
	/// <summary>
	/// Repository for loading mock data without overwriting any actual data.
	/// </summary>
	public class FakeUserRepository : IUserRepository
	{
		public FakeUserRepository() { 
			Debug.WriteLine("Initialized FakeUserRepository - data will be mocked!");
		}

		public User load()
		{
			User user = new User();

			// The following will simulate different users for two-device test cases.

			Device.OnPlatform(
				iOS: () => { user.name = "random_iOS_user_223"; },
				Android: () => { user.name = "random_Android_user_267"; }
			);

			// Alternatively: compiler directives.
			//#if __IOS__
			//	user.name = "Pietje";
			//#elif __ANDROID__
			//	user.name = "Paultje";
			//#endif

			// todo user.media, user.travelogue/entries

			Debug.WriteLine("User info" + user + " loaded!");

			return user;
		}

		public void save()
		{
			Debug.WriteLine("User info saved!");
		}
	}
}

