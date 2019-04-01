using EventManager.ViewModels.Models;
using System;

namespace EventManager.Services.Contracts
{
    public interface IEventService
    {
        int CreateEvent(string eventName, DateTime date, string description, string link,
            CreateAddressViewModel addressViewModel);

        AllEventsIndexViewModel GetEvents();

        void RemoveEvent(int id);

        void GiveRating(int id);
    }
}
