using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManager.Services
{
    public class AddressesService : IAddressesService
    {
        private EventManagerDbContext context;

        private CitiesService citiesService;

        public AddressesService(EventManagerDbContext context)
        {
            this.context = context;
        }

        public uint CreateAddress(string name, string cityName, string countryCode)
        {
            if (context.Cities.Any(c => c.Name.Contains(cityName)))
            {
                uint cityId = citiesService.GetIdByName(cityName);

                var address = new Address() { Name = name, CityId = cityId};

                return address.Id;
            }
            else
            {
                var cityId = citiesService.CreateCity(cityName, countryCode);

                var address = new Address() { Name = name, CityId = cityId};

                return address.Id;
            }
        }
    }
}
