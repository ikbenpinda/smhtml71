using System;

namespace formsapp2
{
	/// <summary>
	/// Repository for loading mock data without overwriting any actual data.
	/// </summary>
	public class FakeUserRepository : IUserRepository
	{
		public FakeUserRepository() { 
			System.Diagnostics.Debug.WriteLine("Initialized FakeUserRepository - data will be mocked!");
		}

		public User load()
		{
			User user = new User();
			user.name = "Pietje";
			// todo user.media, user.travelogue/entries

			System.Diagnostics.Debug.WriteLine("User info" + user + " loaded!");
			return user;
		}

		public void save()
		{
			System.Diagnostics.Debug.WriteLine("User info saved!");
		}
	}
}

