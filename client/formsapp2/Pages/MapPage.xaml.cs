using formsapp2.Code.domain;
using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace formsapp2
{
	public partial class MapPage : ContentPage
	{
		public MapPage()
		{
			InitializeComponent();

			this.Title = "Map";
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

            customMap.CustomPins = new List<CustomPin> { pin };
            customMap.Pins.Add(pin.Pin);
            customMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(51.452058, 5.481995), Distance.FromMiles(1.0)));
        }
	}
}

