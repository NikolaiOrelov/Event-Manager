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
        IEnumerable GetAllEvents();

        int AddEvent(int eventId, string username);

        void RemoveEvent(int eventId, int eventListId);
    }
}
