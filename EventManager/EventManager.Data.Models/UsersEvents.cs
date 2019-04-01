using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Data.Models
{
    public class UsersEvents
    {
        public User User { get; set; }
        [ForeignKey("Event")]
        public string UserId { get; set; }


        public Event Event { get; set; }
        [ForeignKey("User")]
        public int EventId { get; set; }

    }
}
