using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManager.Data.Models
{
    public class Country
    {
        [Key]
        public string CountryCode { get; set; }
            
        [Required]
        public string Name { get; set; }
    }
}
