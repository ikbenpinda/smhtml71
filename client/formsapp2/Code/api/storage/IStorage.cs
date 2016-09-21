using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace formsapp2
{
	public interface IStorage
	{
		Media get(int id);
		Task<List<Image>> getAllPictures();
		void save(Media media);
	}
}

