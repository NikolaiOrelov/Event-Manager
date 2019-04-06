using EventManager.ViewModels.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EventManager.Services.Contracts
{
    public interface IEventListService
    {
        //Returns all Events from EventList to current User
        /// <summary>
        /// Returns all Events from EventList to current User
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns all Events from EventList to current User</returns>
        IEnumerable GetAllEvents(string username);

        //User add Event to her EventList
        /// <summary>
        /// User add Event to her EventList
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="username"></param>
        /// <returns>Returns EventList Id</returns>
        int AddEvent(int eventId, string username);

        //Removed unneeded Event
        /// <summary>
        /// Removed unneeded Event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="username"></param>
        void RemoveEvent(int eventId, string username);
    }
}
