using System;
namespace formsapp2
{
	public static class Time
	{
		/// <summary>
		/// Gets the timestamp in milliseconds since 1970 in UTC.
		/// </summary>
		/// <returns>The unix timestamp.</returns>
		public static long getUnixTimestamp()
		{
			return (long)(DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
		}
	}
}

