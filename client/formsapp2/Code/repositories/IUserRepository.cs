using System;
namespace formsapp2
{
	/// <summary>
	/// Interface for userdata storage.
	/// </summary>
	public interface IUserRepository
	{
		User load();
		void save();
	}
}

