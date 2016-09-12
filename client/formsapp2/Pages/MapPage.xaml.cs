using formsapp2.Code.domain;
using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace formsapp2
{
	public partial class MapPage : ContentPage
	{
        public MapPage()
        {
            this.Title = "Map";
            InitializeComponent();
            var stack = new StackLayout();
            /*var hybridWebView = new HybridWebView
            {
                Uri = "https://maps.google.com/",
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            Padding = new Thickness(0, 20, 0, 0);
            stack.Children.Add(hybridWebView);
            Content = stack;
            
            
            SearchBar searchbar = new SearchBar() { Placeholder = "Search Adress" };
			

			
            var pin = new CustomPin
            {
                Pin = new Pin
                {
                    Type = PinType.Place,
                    Position = new Position(51.452058, 5.481995),
                    Label = "Fontys Hogescholen",
                    Address = "Rachelsmolen 1, 5612 MA Eindhoven"
                },
                Id = "Fontys",
                Url = "https://fontys.nl/"
            };

           // stack.Children.Add(searchbar);
           // stack.Children.Add(customMap);
            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin.Pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(51.452058, 5.481995), Distance.FromMiles(1.0)));
            */
            var browser = new WebView
            {
                Source = "https://maps.google.com/", //"http://145.93.114.134:8081",
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            
            stack.Children.Add(browser);
            Content = stack;
        }
	}
}

