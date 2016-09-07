using Xamarin.Forms;

namespace formsapp2
{
	public partial class formsapp2Page : TabbedPage // This is a tabbed page.
	{
		public formsapp2Page()
		{
			InitializeComponent();

			//var home 	= new HomePage(); 		// var is syntactic sugar for type inference.
			//var log 	= new TraveloguePage(); 
			//var gallery = new GalleryPage();
			//var map 	= new MapPage();

			//Children.Add(home); // Children refers to children of this *Page.
			//Children.Add(log);
			//Children.Add(gallery);
			//Children.Add(map);

			Title = "TITEL";
			var message = "Hello unknown platform!";

			// Device.OpenUrl;
			// Page.DisplayAlert/this.DisplayAlert // not static though!
			// Xamarin.Forms.Maps

			// Use interfaces to deal with platform-specific code
			// Provide implementation in platform project
			// [assembly: Dependency(typeof(ThatOneInterfaceImpl))]
			// var impl = DependencyService.Get<IThatOneInterface>();

			Device.OnPlatform(
				iOS: () => { message = "Hello iOS!";},
				Android: () => { message = "Hello Android";}
			);
		}
	}
}

