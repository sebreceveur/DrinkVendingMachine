using System;
using DrinkVendingMachine.Model;
using Microsoft.EntityFrameworkCore;

namespace DrinkVendingMachine.Data
{
    public class DataBaseContext: DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options): base(options)
        {
        }

        public DbSet<Drink> Drinks { get; set; }
        public DbSet<DrinkStore> DrinkStore { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<CoinStore> Coins { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Drink>().ToTable("Drink");
            modelBuilder.Entity<DrinkStore>().ToTable("DrinkStore");
            modelBuilder.Entity<CatalogItem>().ToTable("CatalogItem");
            modelBuilder.Entity<CoinStore>().ToTable("Coin");
        }
    }
}
