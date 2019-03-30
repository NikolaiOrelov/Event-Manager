using EventManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.ViewModels.Models
{
    public class CreateCityViewModel
    {
        public string Name { get; set; }

        public List<Country> Countries { get; set; }

        public string CountryCode { get; set; }
    }
}
