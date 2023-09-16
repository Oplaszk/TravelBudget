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

        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }

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
                new Category() { Id = 1, Type = "Accomodation", Description = "Hotel ***" }
            );
            modelBuilder.Entity<Comment>().HasData(
                new Comment() { Id = 1, Content = "At the first day..." }
            );
            modelBuilder.Entity<Continent>().HasData(
                new Continent() { Id = 1, Name = "Europe", CountryId = 1 }
            );
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "Poland", Code = "PL", ContinentId = 1, CurrencyId = 1 }
            );
            modelBuilder.Entity<Currency>().HasData(
                new Currency() { Id = 1, Code = "PLN", CountryId = 1}
            );
            modelBuilder.Entity<Expense>().HasData(
                new Expense() { Id = 1, Description = "I bought a souvenir", Price = 15.5, Date = new DateTime(2022, 12, 17, 15, 15, 15), CategoryId = 1, TravelId = 1, CountryId = 1 }
            );
            modelBuilder.Entity<Travel>().HasData(
               new Travel() { Id = 1, StartingDate = new DateTime(2022, 12, 16, 06, 15, 15), FinishDate = new DateTime(2022, 12, 12, 21, 14, 15), Name = "Around Poland", Description = "Visiting castles around Poland", Active = true, CommentId = 1, }
           );

        }
    }
}