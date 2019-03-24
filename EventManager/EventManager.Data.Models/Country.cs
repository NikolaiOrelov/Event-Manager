using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EventManager.Data.Models
{
    public class Country
    {
        [Key]
        public ushort Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
