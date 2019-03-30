using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using System;
using System.Linq;

namespace EventManager.Services
{
    public class CitiesService : ICitiesService
    {
        private EventManagerDbContext context;

        public CitiesService(EventManagerDbContext context)
        {
            this.context = context;
        }

        public uint CreateCity(string name, string countryCode)
        {
            ;
            if (!context.Countries.Any(c => c.CountryCode.Contains(countryCode)))
            {
                throw new InvalidOperationException("There is no Country with this Code!");
            }

            var city = new City() { Name = name, CountryCode = countryCode };

            context.SaveChanges();

            return city.Id;
        }

        public uint GetIdByName(string name)
        {
            var city = context.Cities.FirstOrDefault(c => c.Name == name);

            return city.Id;
        }
    }
}
