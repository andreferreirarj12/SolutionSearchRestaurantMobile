using DomainModel.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class SQLiteContext : DbContext
    {
        private string _dbPath;

        public SQLiteContext(string dbPath)
        {   
            _dbPath = dbPath;
            // Create database if not there
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={_dbPath}");
        }

        public DbSet<Restaurantes> Items { get; set; }
    }
}
