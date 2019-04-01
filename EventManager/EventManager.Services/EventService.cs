using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using System;
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

            var newEvent = new Event()
            {
                EventName = eventName,
                Date = date,
                Description = description,
                Link = link,
                AddressId = addressId
            };

            context.Events.Add(newEvent);
            context.SaveChanges();

            return newEvent.Id;
        }

        public AllEventsIndexViewModel GetEvents()
        {
            throw new NotImplementedException();
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
