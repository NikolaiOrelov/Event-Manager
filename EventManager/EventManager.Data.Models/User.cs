using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EventManager.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.EventLists = new List<EventList>();
        }

        public ICollection<EventList> EventLists { get; set; }
    }
}
