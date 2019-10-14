using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace RPH.Oftamed
{
	public partial class App : Application
	{
		public App ()
		{
			InitializeComponent();

            DBConnection.GetListItems();
            MainPage = new NavigationPage(new MainPage()) {
                BarTextColor = Color.White,
                BarBackgroundColor = Color.OrangeRed
            };
		}

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
