using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManager.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            UserEvent = new List<UserEvent>();
        }

        public ICollection<UserEvent> UserEvent { get; set; }
    }
}
