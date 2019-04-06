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

        //City Service Constructor, sets DbContext:
        /// <summary>
        /// City Service Constructor, sets DbContext:
        /// </summary>
        /// <param name="context"></param>
        public CityService(EventManagerDbContext context)
        {
            this.context = context;
        }

        //Read information about the city and creates it:
        /// <summary>
        /// Read information about the city and creates it:
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="countryCode"></param>
        /// <returns></returns>
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

        //Method that reads a string node with city name, search for it and return its id:
        /// <summary>
        /// Method that reads a string node with city name, search for it and return its id:
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns></returns>
        public int GetCityIdByName(string cityName)
        {
            if (cityName == null)
            {
                throw new InvalidOperationException("There is no city with this name!");
            }

            var city = this.context.Cities.FirstOrDefault(c => c.CityName == cityName);

            return city.Id;
        }

        //Private Methods:

        private bool IsCountryNotExist(string countryCode)
        {
            return !context.Countries.Any(c => c.CountryCode.Contains(countryCode));
        }
    }
}
