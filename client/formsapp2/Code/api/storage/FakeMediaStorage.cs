using System;
namespace formsapp2
{
	public class FakeMediaStorage : IStorage
	{
		public FakeMediaStorage() { 
			System.Diagnostics.Debug.WriteLine("Warning: Using fake MediaStorage.");
		}

		public Media get(int id)
		{
			System.Diagnostics.Debug.WriteLine("Loading image has not been implemented yet.");
			return null;
		}

		public void save(Media media)
		{
			System.Diagnostics.Debug.WriteLine("Saving media(" + media.title + ")...");
		}
	}
}

