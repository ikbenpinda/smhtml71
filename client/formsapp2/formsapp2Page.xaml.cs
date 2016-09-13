using Xamarin.Forms;

namespace formsapp2
{
	public partial class formsapp2Page : TabbedPage // This is a tabbed page.
	{
		public formsapp2Page()
		{
			InitializeComponent();

			// Doing this from XAML isn't as well documented,
			// so let's do this from code.
			var home = new NavigationPage(new HomePage()) { Title = "Home" }; 		// var is syntactic sugar for type inference.
			var log 	= new NavigationPage(new TraveloguePage()) { Title = "Log" }; 
			var gallery = new NavigationPage(new GalleryPage()) { Title = "Gallery" };
			var map 	= new NavigationPage(new MapPage()) { Title = "Map" };

			Children.Add(home); // Children refers to children of this *Page.
			Children.Add(log);
			Children.Add(gallery);
			Children.Add(map);

			//Title = "Home";
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

