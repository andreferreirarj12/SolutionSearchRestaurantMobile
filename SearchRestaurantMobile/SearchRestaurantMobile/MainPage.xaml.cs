using System;
using Xamarin.Forms;

namespace SearchRestaurantMobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            if (Device.RuntimePlatform == Device.UWP)
            {
                imgEntrada.Source = "Images/wallpaper.jpg";
            }
            else if (Device.RuntimePlatform == Device.iOS)
            {
                imgEntrada.Source = "Resources/wallpaper.jpg";
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                imgEntrada.Source = "Resources/drawable/wallpaper.jpg";
            }

            this.btnLogar.Clicked += async (sender, e) =>
            {
                if (Device.RuntimePlatform == Device.UWP)
                {
                    await DisplayAlert("Aviso", "Não é possível se autenticar no Facebook com esta plataforma.", "Aviso");
                    await Navigation.PushAsync(new MapaDetalhe("Desenvolvedor"));
                }
                else
                    await Navigation.PushAsync(new Login());
            };
        }

        private void btnSobre_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new Sobre());
        }
    }
}
