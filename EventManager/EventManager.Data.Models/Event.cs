using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Data.Models
{
    public class Event
    {
        public Event()
        {
            this.EventsEventLists = new List<EventsEventLists>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Range(0, 5)]
        public byte Raiting { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }

        public ICollection<EventsEventLists> EventsEventLists { get; set; }
    }
}
