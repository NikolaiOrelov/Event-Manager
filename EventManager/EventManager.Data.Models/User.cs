using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace EventManager.Data.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            this.UsersEvents = new List<UsersEvents>();
        }

        public ICollection<UsersEvents> UsersEvents { get; set; }
    }
}
