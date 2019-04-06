using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Services
{
    public class CountryService : ICountryService
    {
        private readonly EventManagerDbContext context;

        //Country Service Constructor, sets DbContext:
        public CountryService(EventManagerDbContext context)
        {
            this.context = context;
        }

        //Method that we use in lists with all countires, that returns all CountryName properties:
        public List<Country> GetAll()
        {
            return this.context.Countries.ToList();
        }
    }
}
