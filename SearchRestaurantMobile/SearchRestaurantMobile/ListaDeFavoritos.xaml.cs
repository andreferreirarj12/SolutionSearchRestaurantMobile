using DomainModel.Entities;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SearchRestaurantMobile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListaDeFavoritos : ContentPage
    {
        private IEnumerable<Restaurantes> lstRestaurantesFavoritos = null;

        public ListaDeFavoritos()
        {
            InitializeComponent();
            Listar();
        }

        private void Listar()
        {
            try
            {
                lstPrincipal.ItemsSource = null;
                lstRestaurantesFavoritos = null;

                lstRestaurantesFavoritos = App.Service.GetAllItems();

                lstPrincipal.ItemsSource = lstRestaurantesFavoritos;
            }
            catch (System.Exception ex)
            {
                DisplayAlert("Erro!", ex.Message, "OK");
            }
        }

        public void Handle_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            try
            {
                var rest = e.SelectedItem as Restaurantes;
                App.Service.RemoveItem(rest.idRestaurante);
                Listar();
                DisplayAlert("Suceso", $"Restaurante {rest.Nome} excluído com sucesso!", "Ok");
            }
            catch
            {
            }

        }
        public void Handle_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            try
            {
                var rest = e.Item as Restaurantes;
                App.Service.RemoveItem(rest.idRestaurante);
                Listar();
                DisplayAlert("Suceso", $"Restaurante {rest.Nome} excluído com sucesso!", "Ok");
            }
            catch
            {
            }
        }
    }

}