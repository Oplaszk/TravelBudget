using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TravelBudgetDBContact;
using TravelBudgetDBContact.Repositories;
using TravelBudgetDBContact.Repositories.Interfaces;

namespace TravelBudget
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var cultureInfo = new System.Globalization.CultureInfo("en-GB");
            Thread.CurrentThread.CurrentCulture = cultureInfo;

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.AddConsole();

            builder.Services.AddAntiforgery(options => options.HeaderName = "X-CSRF-TOKEN");

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DBContact>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<DBContact>();
            builder.Services.AddTransient<ITravelRepository, TravelRepository>();
            builder.Services.AddTransient<IExpenseRepository, ExpenseRepository>();
            builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
            builder.Services.AddTransient<ICountryRepository, CountryRepository>();
            builder.Services.AddTransient<IStatisticsRepository, StatisticsRepository>();
            //builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            var app = builder.Build();

            //app.UseSwagger();
            //app.UseSwaggerUI();

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

            app.MapRazorPages();
            app.Run();
        }
    }
}