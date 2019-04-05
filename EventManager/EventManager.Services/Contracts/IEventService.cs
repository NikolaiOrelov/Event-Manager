using EventManager.Data.Models;
using EventManager.ViewModels.Models;
using System;
using System.Collections;

namespace EventManager.Services.Contracts
{
    public interface IEventService
    {
        int CreateEvent(string eventName, DateTime date, string description, string link,
            CreateAddressViewModel addressViewModel);

        IEnumerable GetAllEvents();

        EventDetailsViewModel GetEventDetails(int eventId);
        
        void GiveRating(int id);
    }
}
