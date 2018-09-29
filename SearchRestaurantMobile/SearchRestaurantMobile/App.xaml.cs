using ApplicationService;
using Data;
using DomainService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SearchRestaurantMobile
{
	public partial class App : Application
	{
        public static ResultAppService Service { get; set; }
        public App ()
		{
			InitializeComponent();

            Service = new ResultAppService(new ResultService(new ResutSQLiteRepository(Device.RuntimePlatform)));

            MainPage = new NavigationPage(new MainPage());
        }

        public async static Task NavigateToDetails(string v)
        {
            await App.Current.MainPage.Navigation.PushAsync(new MapaDetalhe(v));
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
