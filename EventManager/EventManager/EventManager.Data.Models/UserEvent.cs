using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventManager.Data.Models
{
    public class UserEvent
    {
        public User User { get; set; }
        [ForeignKey("Event")]
        public string UserId { get; set; }


        public Event Event { get; set; }
        [ForeignKey("User")]
        public uint EventId { get; set; }
        
    }
}
