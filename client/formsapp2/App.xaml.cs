﻿using Xamarin.Forms;

namespace formsapp2
{
	public partial class App : Application
    {
        public static double ScreenHeight;
        public static double ScreenWidth;

        public App()
		{
			InitializeComponent();

			MainPage = new formsapp2Page();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}

