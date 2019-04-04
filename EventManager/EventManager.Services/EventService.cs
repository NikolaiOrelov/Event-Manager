using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using System;
using System.Collections;
using System.Linq;

namespace EventManager.Services
{
    public class EventService : IEventService
    {
        private EventManagerDbContext context;

        private IAddressService addressService;

        public EventService(EventManagerDbContext context, IAddressService addressService)
        {
            this.context = context;
            this.addressService = addressService;
        }

        public int CreateEvent(string eventName, DateTime date, string description, string link,
            CreateAddressViewModel addressViewModel)
        {
            var addressId = default(int);

            if (!context.Addresses.Any(a => a.AddressName.Contains(addressViewModel.AddressName)))
            {
                addressId = addressService.CreateAddress(addressViewModel.AddressName,
                    addressViewModel.CityViewModel);
            }

            addressId = addressService.GetAddressIdByName(addressViewModel.AddressName);
            Address address = context.Addresses.FirstOrDefault(x => x.Id == addressId);

            var newEvent = new Event()
            {
                EventName = eventName,
                Date = date,
                Description = description,
                Link = link,
                AddressId = addressId,
                Address = address
            };

            context.Events.Add(newEvent);
            context.SaveChanges();

            return newEvent.Id;
        }

        public IEnumerable GetAllEvents()
        {
            var models = context.Events.Select(x => new IndexEventViewModel()
            {
                EventId = x.Id,
                Name = x.EventName,
                Date = x.Date,
                Address = x.Address.AddressName,
                City = x.Address.City.CityName
            }).ToList();
            
            return models;
        }

        public EventDetailsViewModel GetEventDetails(int eventId)
        {
            var currentEvent = this.context.Events.FirstOrDefault(x => x.Id == eventId);
            Address currentAddress = context.Addresses.FirstOrDefault(x => x.Id == currentEvent.AddressId);
            City currentCity = context.Cities.FirstOrDefault(x => x.Id == currentAddress.CityId);
            Country country = context.Countries.FirstOrDefault(x => x.CountryCode == currentCity.CountryCode);

            var modelDetails = new EventDetailsViewModel()
            {
                Id = currentEvent.Id,
                EventName = currentEvent.EventName,
                Date = currentEvent.Date,
                Address = currentAddress.AddressName,
                Raiting = currentEvent.Raiting,
                City = currentCity.CityName,
                Country = country.CountryCode,
                Description = currentEvent.Description,
                Link = currentEvent.Link

            };

            return modelDetails;
        }

        public void GiveRating(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveEvent(int id)
        {
            throw new NotImplementedException();
        }
    }
}
