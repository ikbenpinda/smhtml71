using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace formsapp2
{
	public partial class GalleryPage : ContentPage
	{
		IStorage mediaStorage;

		public GalleryPage()
		{
			InitializeComponent();

			this.Title = "Gallery";

			mediaStorage = new FakeMediaStorage();

			initList();

			base.Appearing += (sender, e) => refresh();

			// todo 1 column / * rows gridview

			#region legacy code left here for reference. gridviews suck, FYI.

			//var embeddedImage1 = new Image { Aspect = Aspect.AspectFit };
			//embeddedImage1.Source = ImageSource.FromResource("formsapp2.Assets.1.jpeg");
			//var embeddedImage2 = new Image { Aspect = Aspect.AspectFit };
			//embeddedImage2.Source = ImageSource.FromResource("formsapp2.Assets.2.jpeg");
			//var embeddedImage3 = new Image { Aspect = Aspect.AspectFit };
			//embeddedImage3.Source = ImageSource.FromResource("formsapp2.Assets.3.jpeg");
			//var embeddedImage4 = new Image { Aspect = Aspect.AspectFit };
			//embeddedImage4.Source = ImageSource.FromResource("formsapp2.Assets.4.jpeg");

			//var imagesAvailable = true; // hack use interface for hardware storage.

			//var imageGrid = new Grid(); // todo scrolling, current code is placeholder.
			//imageGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
			//imageGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star)});
			//imageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)});
			//imageGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star)});

			//Label 
			//	topLeft = new Label(),
			//	topRight = new Label(),
			//	bottomLeft = new Label(),
			//	bottomRight = new Label();

			//topLeft.Text = "top left";
			//topRight.Text = "top right";
			//bottomLeft.Text = "bottom left";
			//bottomRight.Text = "bottom right";

			//imageGrid.Children.Add(embeddedImage1/*topLeft*/, 0, 0);
			//imageGrid.Children.Add(embeddedImage2/*topRight*/, 0, 1);
			//imageGrid.Children.Add(embeddedImage3/*bottomLeft*/, 1, 0);
			//imageGrid.Children.Add(embeddedImage4/*bottomRight*/, 1, 1);

			//var nothingFound = new Label();
			//nothingFound.Text = "No images found! :(";

			//if (imagesAvailable)
			//	Content = imageGrid; // todo
			//else
			//	Content = nothingFound; // todo

			#endregion
		}

		public async void initList()
		{
			var window = new ScrollView();
			var stacklayout = new StackLayout();

			List<Image> images = await mediaStorage.getAllPictures();
			if (images.Count < 1)
			{
				FakeIt(); // hack - server needs additional  yet.
				return;
			}
			Debug.WriteLine("IMAGES.COUNT: " + images.Count);

			foreach (var image in images)
			{
				stacklayout.Children.Add(image);
			}

			window.Content = stacklayout;
			Content = window;
		}

		void FakeIt()
		{
			var window = new ScrollView();
			var stacklayout = new StackLayout();
			var images = new List<Image>(){
				new Image(){Aspect = Aspect.AspectFit, Source = ImageSource.FromResource("formsapp2.assets.1.jpeg")},
				new Image(){Aspect = Aspect.AspectFit, Source = ImageSource.FromResource("formsapp2.assets.1.jpeg") },
				new Image(){Aspect = Aspect.AspectFit, Source = ImageSource.FromResource("formsapp2.assets.1.jpeg") },
				new Image(){Aspect = Aspect.AspectFit, Source = ImageSource.FromResource("formsapp2.assets.1.jpeg") },
				new Image(){Aspect = Aspect.AspectFit, Source = ImageSource.FromResource("formsapp2.assets.1.jpeg") },
				new Image(){Aspect = Aspect.AspectFit, Source = ImageSource.FromResource("formsapp2.assets.1.jpeg") },
				new Image(){Aspect = Aspect.AspectFit, Source = ImageSource.FromResource("formsapp2.assets.1.jpeg") },
				new Image(){Aspect = Aspect.AspectFit, Source = ImageSource.FromResource("formsapp2.assets.1.jpeg") }
			};

			foreach (var image in images)
			{
				stacklayout.Children.Add(image); 
			}

			window.Content = stacklayout;
			Content = window;
		}

		public void refresh()
		{
			initList();
		}
	}
}

