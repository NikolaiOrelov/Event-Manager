using EventManager.Data.Models;
using System.Collections.Generic;

namespace EventManager.ViewModels.Models
{
    public class CreateCityViewModel
    {
        public string CityName { get; set; }

        public List<Country> Countries { get; set; }

        public string CountryCode { get; set; }
    }
}
