using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventManager.Data.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public City City { get; set; }
        [ForeignKey("City")]
        public int? CityId { get; set; }
    }
}
