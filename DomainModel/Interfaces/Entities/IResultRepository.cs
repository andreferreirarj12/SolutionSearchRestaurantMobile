using DomainModel.APIGoogle;
using DomainModel.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomainModel.Interfaces
{
    public interface IResultRepository
    {
        void Add(Restaurantes item);
        void Update(Restaurantes item);
        IEnumerable<Restaurantes> GetAll();
        IEnumerable<Restaurantes> GetAll(string longitude, string latitude);
        Restaurantes Get(int id);
        void Remove(int id);
        void RemoveAll();
    }
}
