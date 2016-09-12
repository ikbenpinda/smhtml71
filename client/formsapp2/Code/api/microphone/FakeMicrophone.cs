using System;
namespace formsapp2
{
	public class FakeMicrophone : IMicrophone
	{
		public FakeMicrophone(){ 
			System.Diagnostics.Debug.WriteLine("Warning: Using fake Microphone.");
		}

		public void record()
		{
			System.Diagnostics.Debug.WriteLine("Recording microphone...but not really tho.");
		}
	}
}

