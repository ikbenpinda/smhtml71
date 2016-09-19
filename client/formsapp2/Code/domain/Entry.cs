using System;
namespace formsapp2
{
	public class Entry
	{
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime Date { get; set; }
		public int entryNumber { get; set; }

		public Entry() { }

		public override string ToString()
		{
			return Title + " - " + Content;
		}
	}
}

