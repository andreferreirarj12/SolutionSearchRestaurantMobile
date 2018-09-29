using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchRestaurantMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MapaDetalhe : ContentPage
	{
        private IEnumerable<Restaurantes> results = null;
       
        public MapaDetalhe (string user)
		{
			InitializeComponent ();
            lblUser.Text = "BEM VINDO " + user;
            PopularDados();
        }

        private void btnFavoritos_Clicked(object sender, EventArgs e)
        {   
            Navigation.PushAsync(new ListaDeFavoritos());
        }

        private async void PopularDados()
        {    
            try
            {
                //Obtenho todos os restaurantes veganos em um raio de 5 km
                //var location = await Geolocation.GetLastKnownLocationAsync();
                //var results = await App.Service.GetAllItems(location.Longitude.ToString(), location.Latitude.ToString());                                
                results = await App.Service.GetAllItems("12,233", "15,112");
                                
                stackPrincipal.Children.Clear();

                //Preencho na tela
                for (var i = 0; i < results.ToList().Count; i++)
                {
                    AdicionarComponentesNaTela(results.ToList()[i]);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", ex.Message, "Erro");
            }
        }

        private void AdicionarComponentesNaTela(Restaurantes restaurante)
        {            
            try
            {               
                var lblNome = new Label
                {
                    Text = restaurante.Nome,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.White
                };

                stackPrincipal.Children.Add(lblNome);

                var lblId = new Label
                {
                    Text = restaurante.idRestaurante.ToString(),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.White,
                    IsVisible = false
                };

                stackPrincipal.Children.Add(lblId);

                var lblDescricao = new Label
                {
                    Text = restaurante.Descricao.ToString(),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.White                    
                };

                stackPrincipal.Children.Add(lblDescricao);

                var lblEndereco = new Label
                {
                    Text = restaurante.Endereco.ToString(),
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    TextColor = Color.White
                };

                stackPrincipal.Children.Add(lblEndereco);

                var imagem = new Image
                {
                    Source = restaurante.Imagem,
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };

                stackPrincipal.Children.Add(imagem);

                var btnSalvar = new Button
                {
                    Text = "Salvar",
                    VerticalOptions = LayoutOptions.Start,
                    HorizontalOptions = LayoutOptions.FillAndExpand,
                    BackgroundColor = Color.Transparent,
                    TextColor = Color.White,
                    BorderColor = Color.White,
                    AutomationId = restaurante.idRestaurante.ToString()
                };                
                btnSalvar.Clicked += SaveButtonClicked;

                stackPrincipal.Children.Add(btnSalvar);                                
                
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        void SaveButtonClicked(object sender, EventArgs args)
        {
            try
            {
                Button button = (Button)sender;
                Restaurantes item = (from x in results where x.idRestaurante == int.Parse(button.AutomationId) select x).First();
                App.Service.AddItem(item);
                DisplayAlert("Sucesso!", "Restaurante salvo com sucesso!", "OK");
            }
            catch (Exception ex)
            {
                DisplayAlert("Erro", ex.Message, "Erro");
            }
            
        }    
    }

}