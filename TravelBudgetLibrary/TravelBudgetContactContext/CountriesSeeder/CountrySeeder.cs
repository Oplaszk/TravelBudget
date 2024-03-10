using TravelBudgetDBContact.CountriesSeeder;
using TravelBudgetDBContact;
using TravelBudgetDBModels.Models;

public class CountrySeeder
{
    private readonly DBContact _context;

    public CountrySeeder(DBContact context)
    {
        _context = context;
    }

    //public void Seed()
    //{
    //    if (!_context.Countries.Any())
    //    {
    //        var countriesData = ReadCountriesFromCSV("Countries.csv"); // Ustaw nazwę pliku CSV

    //        foreach (var countryData in countriesData)
    //        {
    //            var continent = _context.Continents.FirstOrDefault(c => c.Name == countryData.ContinentName);
    //            var currency = _context.Currencies.FirstOrDefault(c => c.Code == countryData.CurrencyCode);

    //            if (continent != null && currency != null)
    //            {
    //                var country = new Country
    //                {
    //                    Name = countryData.Name,
    //                    Code = countryData.Code,
    //                    ContinentId = continent.Id,
    //                    CurrencyId = currency.Id
    //                };

    //                _context.Countries.Add(country);
    //            }
    //        }

    //        _context.SaveChanges();
    //    }
    //}

    //private List<CountryData> ReadCountriesFromCSV(string filePath)
    //{
    //    // Implementacja wczytywania danych z pliku CSV
    //    // Zwróć listę obiektów zawierających informacje o krajach
    //}
}
