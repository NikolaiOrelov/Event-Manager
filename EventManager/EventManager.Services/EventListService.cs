using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Services
{
    public class EventListService : IEventListService
    {
        private EventManagerDbContext context;

        public EventListService(EventManagerDbContext context)
        {
            this.context = context;
        }
            
        public int AddEvent(int eventId, string username)
        {
            var eventToAdd = context.Events.FirstOrDefault(e => e.Id == eventId);

            if (IsEventListNotExist(username))
            {
                Create(username);
            }
            

            var eventList = context.EventLists
                .Include(el => el.Owner)
                .FirstOrDefault(el => el.Owner.UserName == username);

            var eventEventList = new EventsEventLists()
            {
                EventId=eventToAdd.Id,
                Event=eventToAdd,
                EventListId=eventList.Id,
                EventList=eventList
            };

            this.context.Events.FirstOrDefault(e=>e.Id==eventToAdd.Id).EventsEventLists.Add(eventEventList);
            this.context.EventLists.FirstOrDefault(el => el.Id == eventList.Id).EventsEventLists.Add(eventEventList);

            context.SaveChanges();

            return eventList.Id;
        }

        public void RemoveEvent(int eventId, int eventListId)
        {
            var removeEvent = this.context.Events.Find(eventId);
            removeEvent.EventsEventLists = null;

            var removeEventList = this.context.EventLists.Find(eventListId);
            removeEventList.EventsEventLists = null;

            this.context.SaveChanges();
        }

        public IEnumerable GetAllEvents(int eventListId)
        {
            var eventList = this.context.EventLists.FirstOrDefault(el => el.Id==eventListId);

            var events = new List<Event>();

            foreach (var currEvent in eventList.EventsEventLists)
            {
                events.Add(currEvent.Event);
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

        private bool IsEventListNotExist(string username)
        {
            return !this.context.EventLists.Any(x => x.Owner.UserName.Contains(username));
        }

        private void Create(string username)
        {
            var owner = this.context.Users.FirstOrDefault(u => u.UserName == username);

            var eventList = new EventList()
            {
                Owner = owner
            };

            this.context.EventLists.Add(eventList);

            this.context.SaveChanges();
        }
    }
}
