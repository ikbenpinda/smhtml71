using System;
using System.Collections.Generic;

namespace formsapp2
{
	public class Travelogue
	{
		public string name { get; set; }
		public User User { get; set; }
		public List<Entry> Entries  { get; set; }
		public DateTime Created { get; set; }
		public DateTime LastUpdated { get; set; }

		public Travelogue()
		{
			name = null;
			User = null;

			Created = new DateTime();
			Entries = new List<Entry>();
			LastUpdated = Created;
		}

		/// <summary>
		/// Full initializer.
		/// </summary>
		/// <param name="name">Name.</param>
		/// <param name="user">User.</param>
		public Travelogue(string name, User user)
		{
			this.name = name;
			this.User = user;

			Created = new DateTime();
			Entries = new List<Entry>();
			LastUpdated = Created;

		}

		public override string ToString()
		{
			return name;
		}
	}
}

