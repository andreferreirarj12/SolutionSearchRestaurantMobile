using DomainModel.APIGoogle;
using DomainModel.Entities;
using DomainModel.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DomainService
{
    public class ResultService
    {
        private IResultRepository _repository;

        public ResultService(IResultRepository repository)
        {
            _repository = repository;
        }

        public void AddItem(Restaurantes item)
        {
            _repository.Add(item);
        }

        public void UpdateItem(Restaurantes item)
        {
            _repository.Update(item);
        }

        public IEnumerable<Restaurantes> GetAllItems()
        {
            return _repository.GetAll();
        }

        public IEnumerable<Restaurantes> GetAllItems(string longitude, string latitude)
        {
            return _repository.GetAll(longitude, latitude);
        }

        public Restaurantes GetItem(int id)
        {
            return _repository.Get(id);
        }

        public void RemoveItem(int id)
        {
            _repository.Remove(id); //Remove from Repository
        }

        public void RemoveAllItems()
        {
            _repository.RemoveAll();
        }
    }
}
