using System;
namespace formsapp2
{
	public interface IStorage
	{
		Media get(int id);
		void save(Media media);
	}
}

