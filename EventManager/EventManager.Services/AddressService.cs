using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using System.Linq;

namespace EventManager.Services
{
    public class AddressService : IAddressService
    {
        private EventManagerDbContext context;

        private ICityService citiesService;

        public AddressService(EventManagerDbContext context, ICityService citiesService)
        {
            this.context = context;
            this.citiesService = citiesService;
        }

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

        public int GetAddressIdByName(string addressName)
        {
            var address = this.context.Addresses.FirstOrDefault(a => a.AddressName == addressName);

            return address.Id;
        }

        private bool IsCityNotExist(CreateCityViewModel cityViewModel)
        {
            return !context.Cities.Any(c => c.CityName.Contains(cityViewModel.CityName));
        }
    }
}
