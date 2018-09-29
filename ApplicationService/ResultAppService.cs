using DomainModel.APIGoogle;
using DomainModel.Entities;
using DomainModel.Interfaces;
using DomainService;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApplicationService
{
    public class ResultAppService 
    {
        public ObservableCollection<Restaurantes> Items { get; set; }
        private ResultService _itemService;               
        
        public ResultAppService(ResultService resultService)
        {
            _itemService = resultService;
            Items = new ObservableCollection<Restaurantes>();

            //Fill the ObservableCollection
            var items = GetAllItems().OrderBy(i => i.idRestaurante);
            foreach (var item in items)
                Items.Add(item);
        }

        public void AddItem(Restaurantes item)
        {
            Items.Add(item); //ObservableCollection
            _itemService.AddItem(item);
        }

        public void UpdateItem(Restaurantes item)
        {
            _itemService.UpdateItem(item);
        }

        public IEnumerable<Restaurantes> GetAllItems()
        {
            return _itemService.GetAllItems();
        }

        public async Task<IEnumerable<Restaurantes>> GetAllItems(string longitude, string latitude)
        {
            List<Restaurantes> ret = null;
            try
            {
                HttpClient client = new HttpClient();                
                string url = string.Format("http://localhost:63651/api/Result/{0}/{1}", longitude, latitude);
                var response = await client.GetStringAsync(url);
                var ListaRestaurantes = JsonConvert.DeserializeObject<List<Result>>(response);

                if (ListaRestaurantes != null)
                {
                    ret = new List<Restaurantes>();

                    foreach (var item in ListaRestaurantes)
                    {
                        Restaurantes r = new Restaurantes();
                        r.idRestaurante = int.Parse(item.id);
                        r.Nome = item.name;
                        r.Descricao = item.reference;
                        r.Endereco = item.place_id;
                        r.Imagem = item.photos[0].photo_reference;
                       
                        ret.Add(r);
                    }
                }               
                
                return ret;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void RemoveItem(int id)
        {
            var originalItem = Items.SingleOrDefault(i => i.idRestaurante == id);
            Items.Remove(originalItem); //Remove from ObservableCollection
            _itemService.RemoveItem(id); //Remove from Repository
        }

        public void RemoveAllItems()
        {
            Items.Clear();
            _itemService.RemoveAllItems();
        }       

    }
}
