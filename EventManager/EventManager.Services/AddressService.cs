using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using System;
using System.Linq;

namespace EventManager.Services
{
    public class AddressService : IAddressService
    {
        private EventManagerDbContext context;

        private ICityService citiesService;

        //Address Service Constructor, sets Services and DbContext:
        /// <summary>
        /// Address Service Constructor, sets Services and DbContext:
        /// </summary>
        /// <param name="context"></param>
        /// <param name="citiesService"></param>
        public AddressService(EventManagerDbContext context, ICityService citiesService)
        {
            this.context = context;
            this.citiesService = citiesService;
        }

        //Read information about the address and creates it:
        /// <summary>
        /// Read information about the address and creates it:
        /// </summary>
        /// <param name="addressName"></param>
        /// <param name="cityViewModel"></param>
        /// <returns></returns>
        public int CreateAddress(string addressName, CreateCityViewModel cityViewModel)
        {
            var cityId = default(int);

            if (IsCityNotExist(cityViewModel))
            {
                cityId = this.citiesService.CreateCity(cityViewModel.CityName, cityViewModel.CountryCode);
            }
            else
            {
                cityId = this.citiesService.GetCityIdByName(cityViewModel.CityName);
            }

            var city = context.Cities.FirstOrDefault(x => x.Id == cityId);

            var address = new Address() { AddressName = addressName, CityId = cityId, City = city };

            this.context.Addresses.Add(address);
            this.context.SaveChanges();

            return address.Id;
        }

        //Method that reads a string node with address name, search for it and return its id:
        /// <summary>
        /// Method that reads a string node with address name, search for it and return its id:
        /// </summary>
        /// <param name="addressName"></param>
        /// <returns></returns>
        public int GetAddressIdByName(string addressName)
        {
            if (addressName == null)
            {
                throw new InvalidOperationException("There is no address with this name!");
            }

            var address = this.context.Addresses.FirstOrDefault(a => a.AddressName == addressName);

            return address.Id;
        }

        //Private Methods:

        private bool IsCityNotExist(CreateCityViewModel cityViewModel)
        {
            return !context.Cities.Any(c => c.CityName.Contains(cityViewModel.CityName));
        }
    }
}
