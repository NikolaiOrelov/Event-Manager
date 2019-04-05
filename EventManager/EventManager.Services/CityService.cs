using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using System;
using System.Linq;

namespace EventManager.Services
{
    public class CityService : ICityService
    {
        private EventManagerDbContext context;

        public CityService(EventManagerDbContext context)
        {
            this.context = context;
        }

        public int CreateCity(string cityName, string countryCode)
        {
            if (IsCountryNotExist(countryCode))
            {
                throw new InvalidOperationException("There is no Country with this Code!");
            }

            Country country = context.Countries.FirstOrDefault(x => x.CountryCode == countryCode);

            var city = new City() { CityName = cityName, CountryCode = countryCode, Country = country };

            this.context.Cities.Add(city);
            this.context.SaveChanges();

            return city.Id;
        }

        public int GetCityIdByName(string cityName)
        {
            var city = this.context.Cities.FirstOrDefault(c => c.CityName == cityName);

            return city.Id;
        }

        private bool IsCountryNotExist(string countryCode)
        {
            return !context.Countries.Any(c => c.CountryCode.Contains(countryCode));
        }
    }
}
