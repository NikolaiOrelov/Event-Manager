using EventManager.Data.Models;
using EventManager.ViewModels.Models;
using System;
using System.Collections;

namespace EventManager.Services.Contracts
{
    public interface IEventService
    {
        //Create future Event
        /// <summary>
        /// Create future Event
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="link"></param>
        /// <param name="addressViewModel"></param>
        /// <returns>Return Event Id</returns>
        int CreateEvent(string eventName, DateTime date, string description, string link,
            CreateAddressViewModel addressViewModel);

        //Returns Collection from all exists Events
        /// <summary>
        /// Returns Collection from all exists Events
        /// </summary>
        /// <returns>Collection from all exists Events</returns>
        IEnumerable GetAllEvents();

        //Returns ViewModel which show info for all Events
        /// <summary>
        /// Returns ViewModel which show info for all Events
        /// </summary>
        /// <param name="eventId"></param>
        /// <returns>ViewModel which show info for all Events</returns>
        EventDetailsViewModel GetEventDetails(int eventId);
    }
}
