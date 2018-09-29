using DomainModel.APIGoogle;
using DomainModel.Entities;
using DomainModel.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Data
{
    public class ResutSQLiteRepository : IResultRepository
    {
        private SQLiteContext _db;

        public ResutSQLiteRepository(string devicePlatform)
        {
            string dbPath = String.Empty;

            switch (devicePlatform)
            {
                case "UWP":
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "restaurantVegan.sqlite");
                    break;
                case "iOS":
                    dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "data", "restaurantVegan.sqlite");
                    break;
                case "Android":
                    dbPath = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments), "restaurantVegan.sqlite");
                    break;
            }

            _db = new SQLiteContext(dbPath);
        }

        public void Add(Restaurantes item)
        {
            var dado = _db.Items.SingleOrDefault(i => i.idRestaurante == item.idRestaurante);

            if(dado == null)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
            }            
            else
                throw new Exception("Dado Cadastrado");
        }

        public void Update(Restaurantes item)
        {
            //##### Update the LocalDatabase #####
            var entry = _db.Entry(item);
            _db.Items.Attach(item);
            entry.State = EntityState.Modified;
            _db.SaveChanges();
            //####################################
        }

        public IEnumerable<Restaurantes> GetAll()
        {
            return _db.Items;
        }

        public void Remove(int id)
        {
            var originalItem = _db.Items.SingleOrDefault(i => i.idRestaurante == id);
            _db.Items.Remove(originalItem);
            _db.SaveChanges();
        }

        public void RemoveAll()
        {
            foreach (var item in _db.Items)
                _db.Items.Remove(item);
            _db.SaveChanges();
        }

        public Restaurantes Get(int id)
        {
            return _db.Items.SingleOrDefault(i => i.idRestaurante == id);
        }

        public IEnumerable<Restaurantes> GetAll(string longitude, string latitude)
        {
            throw new NotImplementedException();
        }
    }
}
