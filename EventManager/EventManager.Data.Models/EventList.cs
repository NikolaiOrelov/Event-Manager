using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Data.Models
{
    public class EventList
    {
        public EventList()
        {
            this.EventsEventLists = new List<EventsEventLists>();
        }

        [Key]
        public int Id { get; set; }

        [Required]  
        public User Owner { get; set; }

        //[Required]
        //[ForeignKey("Event")]
        //public int EventId { get; set; }

        //public Event Event { get; set; }

        public ICollection<EventsEventLists> EventsEventLists { get; set; }
    }
}
