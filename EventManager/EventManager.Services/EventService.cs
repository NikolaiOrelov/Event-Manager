using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Linq;

namespace EventManager.Services
{
    public class EventService : IEventService
    {
        private EventManagerDbContext context;

        private IAddressService addressService;

        //Event Service Constructor, sets addressService and DbContext:
        /// <summary>
        /// Event Service Constructor, sets addressService and DbContext:
        /// </summary>
        /// <param name="context"></param>
        /// <param name="addressService"></param>
        public EventService(EventManagerDbContext context, IAddressService addressService)
        {
            this.context = context;
            this.addressService = addressService;
        }

        //Read information about the event and the address and creates both, if necessary:
        /// <summary>
        /// Read information about the event and the address and creates both, if necessary:
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="link"></param>
        /// <param name="addressViewModel"></param>
        /// <returns></returns>
        public int CreateEvent(string eventName, DateTime date, string description, string link,
            CreateAddressViewModel addressViewModel)
        {
            var addressId = default(int);

            if (IsAddressNotExist(addressViewModel))
            {
                addressId = addressService.CreateAddress(addressViewModel.AddressName,
                addressViewModel.CityViewModel);
            }
            else
            {
                addressId = addressService.GetAddressIdByName(addressViewModel.AddressName);
            }

            var address = context.Addresses.FirstOrDefault(x => x.Id == addressId);

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

        //Method that we use in our Index.cshtml View class to show all events available:
        /// <summary>
        /// Method that we use in our Index.cshtml View class to show all events available:
        /// </summary>
        /// <returns></returns>
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

        //Method that we use in our Details.cshtml View class to show all information about the current event:
        /// <summary>
        /// Method that we use in our Details.cshtml View class to show all information about the current event:
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns></returns>
        public EventDetailsViewModel GetEventDetails(int eventId)
        {
            var currentEvent = this.context.Events
                .Include(x=>x.Address)
                .Include(x=>x.Address.City)
                .Include(x => x.Address.City.Country)
                .FirstOrDefault(x => x.Id == eventId);

            var modelDetails = new EventDetailsViewModel()
            {
                EventId = currentEvent.Id,
                EventName = currentEvent.EventName,
                Date = currentEvent.Date,
                Address = currentEvent.Address.AddressName,
                City = currentEvent.Address.City.CityName,
                Country = currentEvent.Address.City.Country.Name,
                Description = currentEvent.Description,
                Link = currentEvent.Link
            };

            return modelDetails;
        }
        
        //Private Methods:

        private bool IsAddressNotExist(CreateAddressViewModel addressViewModel)
        {
            return !context.Addresses.Any(a => a.AddressName.Contains(addressViewModel.AddressName));
        }
    }
}
