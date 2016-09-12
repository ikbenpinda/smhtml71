using System;
namespace formsapp2
{
	public interface IMediaStorage
	{
		Media get(int id);
		void save(Media media);
	}
}

