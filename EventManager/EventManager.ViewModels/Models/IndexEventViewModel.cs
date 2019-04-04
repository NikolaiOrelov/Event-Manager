using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.ViewModels.Models
{
    public class IndexEventViewModel
    {
        public int EventId { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public string Address { get; set; }

        public string City { get; set; }
        
    }
}
