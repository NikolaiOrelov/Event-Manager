using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EventManager.Data.Models
{
    public class City
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
     
        [ForeignKey("Country")]
        public string CountryCode { get; set; }
        public Country Country { get; set; }
    }
}
