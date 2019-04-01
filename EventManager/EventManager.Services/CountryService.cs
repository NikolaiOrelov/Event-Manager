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
        
        public CountryService(EventManagerDbContext context)
        {
            this.context = context;
        }

        public List<Country> GetAll()
        {
            return this.context.Countries.ToList();
        }
    }
}
