using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManager.Data.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string CityName { get; set; }

        [ForeignKey("Country")]
        public string CountryCode { get; set; }
        public Country Country { get; set; }
    }
}
