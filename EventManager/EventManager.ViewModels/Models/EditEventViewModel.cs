using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.ViewModels.Models
{
    public class EditEventViewModel
    {
        public string EventName { get; set; }
        
        public DateTime Date { get; set; }
        
        public string Description { get; set; }

        public string Link { get; set; }
    }
}
