using Microsoft.EntityFrameworkCore;
using TravelBudgetContactContext;
using TravelBudgetContactContext.Repositories;

namespace TravelBudget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<ContactContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddTransient<TravelRepository>();
            builder.Services.AddTransient<ExpenseRepository>();
            builder.Services.AddTransient<CategoryRepository>();
            builder.Services.AddTransient<CountryRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Travel}/{action=Index}/{id?}");

            app.Run();
        }
    }
}