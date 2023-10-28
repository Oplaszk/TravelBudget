using Microsoft.EntityFrameworkCore;
using TravelBudgetModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelBudgetContactContext
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Continent> Continents { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Travel> Travels { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category() { Id = 1, Type = "Accomodation"},
                new Category() { Id = 2, Type = "Food"},
                new Category() { Id = 3, Type = "Transport" },
                new Category() { Id = 4, Type = "Atractions"},
                new Category() { Id = 5, Type = "Shopping"},
                new Category() { Id = 6, Type = "Others"}
            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment() { Id = 1, Content = "At the first day..."},
                new Comment() { Id = 2, Content = "At the first day..." },
                new Comment() { Id = 3, Content = "At the first day..." }
            );
            modelBuilder.Entity<Continent>().HasData(
                new Continent() { Id = 1, Name = "Europe"},
                new Continent() { Id = 2, Name = "Africa"},
                new Continent() { Id = 3, Name = "Asia"},
                new Continent() { Id = 4, Name = "North America"},
                new Continent() { Id = 5, Name = "South America"},
                new Continent() { Id = 6, Name = "Australia"},
                new Continent() { Id = 7, Name = "Zelandia"},
                new Continent() { Id = 8, Name = "Antarctica"}
            );
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "Poland", Code = "PL", ContinentId = 1, CurrencyId = 1 },
                new Country() { Id = 2, Name = "Sweden", Code = "SE", ContinentId = 2, CurrencyId = 5 },
                new Country() { Id = 3, Name = "Brazil", Code = "BR", ContinentId = 5, CurrencyId = 3 },
                new Country() { Id = 4, Name = "Costa Rica", Code = "CR", ContinentId = 5, CurrencyId = 3 },
                new Country() { Id = 5, Name = "Japan", Code = "CJP", ContinentId = 3, CurrencyId = 6 }
            );
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Code = "PLN" },
                new Currency() { Id = 2, Code = "EUR" },
                new Currency() { Id = 3, Code = "USD" },
                new Currency() { Id = 4, Code = "GBP" },
                new Currency() { Id = 5, Code = "SEK" },
                new Currency() { Id = 6, Code = "JPY" }
            );
            modelBuilder.Entity<Expense>().HasData(
                new Expense() { Id = 1, Description = "I bought a souvenir", Price = 15.5, Date = new DateTime(2022, 12, 17, 15, 15, 0), CategoryId = 1, TravelId = 1, CountryId = 1 }
            );
            modelBuilder.Entity<Travel>().HasData(
               new Travel() { Id = 1, StartingDate = new DateTime(2022, 12, 16, 06, 15, 0), FinishDate = new DateTime(2022, 12, 12, 21, 15, 0), Name = "Around Poland", Description = "Visiting castles around Poland", Active = false, CommentId = 1, },
               new Travel() { Id = 2, StartingDate = new DateTime(2023, 09, 18, 06, 15, 0), FinishDate = new DateTime(2023, 10, 12, 21, 15, 0), Name = "Around Poland", Description = "Visiting forests", Active = true, CommentId = 2, },
               new Travel() { Id = 3, StartingDate = new DateTime(2023, 06, 18, 06, 15, 0), FinishDate = new DateTime(2023, 12, 12, 21, 15, 0), Name = "Around Poland", Description = "Mazurian lakes", Active = true, CommentId = 3, }
           );

        }
    }
}