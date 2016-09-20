
using Xamarin.Forms;
using XLabs.Forms.Controls;
using XLabs.Serialization.JsonNET;

namespace formsapp2
{
    public partial class MapPage : ContentPage
	{
        public MapPage()
        {
            this.Title = "Map";
            InitializeComponent();
            var stack = new StackLayout();
            var browser = new HybridWebView(new JsonSerializer())
            {
                Source = "https://maps.google.com/",
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };

            stack.Children.Add(browser);
            Content = stack;
        }
	}
}

