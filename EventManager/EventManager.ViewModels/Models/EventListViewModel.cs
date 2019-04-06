using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.ViewModels.Models
{
    public class EventListViewModel
    {
        public IEnumerable<IndexEventViewModel> Events { get; set; }
    }
}
