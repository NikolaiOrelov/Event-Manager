using System;

namespace EventManager.ViewModels.Models
{
    public class CreateEventViewModel
    {
        public string EventName { get; set; }

        public DateTime Date { get; set; }

        public CreateAddressViewModel AddressViewModel { get; set; }

        public string Description { get; set; }

        public string Link { get; set; }
    }
}
