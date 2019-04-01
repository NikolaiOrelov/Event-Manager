using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string AddressName { get; set; }

        public City City { get; set; }
        [ForeignKey("City")]
        public int? CityId { get; set; }
    }
}
