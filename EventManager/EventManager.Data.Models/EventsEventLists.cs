using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Data.Models
{
    public class EventsEventLists
    {
        public int EventId { get; set; }
        public Event Event { get; set; }

        public int EventListId { get; set; }
        public EventList EventList { get; set; }
    }
}
