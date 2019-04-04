using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.ViewModels.Models
{
    public class EventDetailsViewModel
    {
        public int Id { get; set; }
        
        public string EventName { get; set; }
        
        public DateTime Date { get; set; }
        
        public byte Raiting { get; set; }
        
        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
        
    }
}
