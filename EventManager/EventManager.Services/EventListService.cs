using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Services
{
    public class EventListService : IEventListService
    {
        private EventManagerDbContext context;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        public EventListService(EventManagerDbContext context)
        {
            this.context = context;
        }

        //User add Event to her EventList
        /// <summary>
        /// User add Event to her EventList
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="username"></param>
        /// <returns>Returns EventList Id</returns>
        public int AddEvent(int eventId, string username)
        {
            var eventToAdd = context.Events.FirstOrDefault(e => e.Id == eventId);

            if (IsEventListNotExist(username))
            {
                Create(username);
            }


            var eventList = context.EventLists
                .Include(el => el.Owner)
                .Include(el => el.EventsEventLists)
                .FirstOrDefault(el => el.Owner.UserName == username);

            if (!IsEventExistInCurrentEventList(eventId, eventList))
            {
                return -1;
            }

            var eventEventList = new EventsEventLists()
            {
                EventId = eventToAdd.Id,
                Event = eventToAdd,
                EventListId = eventList.Id,
                EventList = eventList
            };

            context.Events
                .FirstOrDefault(e => e.Id == eventToAdd.Id).EventsEventLists.Add(eventEventList);
            context.EventLists
                .FirstOrDefault(el => el.Id == eventList.Id).EventsEventLists.Add(eventEventList);

            context.SaveChanges();

            return eventList.Id;
        }

        //Removed unneeded Event
        /// <summary>
        /// Removed unneeded Event
        /// </summary>
        /// <param name="eventId"></param>
        /// <param name="username"></param>
        public void RemoveEvent(int eventId, string username)
        {
            context.Events
                .Include(x => x.EventsEventLists)
                .FirstOrDefault(x => x.Id == eventId).EventsEventLists = null;

            context.Events
                 .Include(x => x.EventsEventLists)
                 .FirstOrDefault(x => x.Id == eventId).EventsEventLists = null;

            context.SaveChanges();
        }

        //Returns all Events from EventList to current User
        /// <summary>
        /// Returns all Events from EventList to current User
        /// </summary>
        /// <param name="username"></param>
        /// <returns>Returns all Events from EventList to current User</returns>
        public IEnumerable GetAllEvents(string username)
        {
            var eventList = context.EventLists
                .Include(el => el.EventsEventLists)
                .Include(el => el.Owner)
                .Include(el => el.EventsEventLists)
                .FirstOrDefault(el => el.Owner.UserName == username);

            var events = new List<Event>();

            if (eventList == null)
            {
                return default(IEnumerable<IndexEventViewModel>);
            }

            foreach (var currEvent in eventList.EventsEventLists)
            {
                events.Add(context.Events
                    .Include(x => x.Address)
                    .Include(x => x.Address.City)
                    .Include(x => x.Address.City.Country)
                    .FirstOrDefault(x => x.Id == currEvent.EventId));
            }

            var models = events.Select(e => new IndexEventViewModel()
            {
                EventId = e.Id,
                Name = e.EventName,
                Date = e.Date,
                Address = e.Address.AddressName,
                City = e.Address.City.CityName
            }).ToList();

            return models;
        }

        private void Create(string username)
        {
            var owner = context.Users.FirstOrDefault(u => u.UserName == username);

            var eventList = new EventList()
            {
                Owner = owner
            };

            context.EventLists.Add(eventList);

            context.SaveChanges();
        }


        private static bool IsEventExistInCurrentEventList(int eventId, EventList eventList)
        {
            return eventList.EventsEventLists.FirstOrDefault(x => x.EventId == eventId) == null;
        }


        private bool IsEventListNotExist(string username)
        {
            return !context.EventLists.Any(x => x.Owner.UserName.Contains(username));
        }

    }
}
