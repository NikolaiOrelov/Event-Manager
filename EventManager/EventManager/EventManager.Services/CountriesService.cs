using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EventManager.Services
{
    public class CountriesService : ICountriesService
    {
        private readonly EventManagerDbContext context;
        
        public CountriesService(EventManagerDbContext context)
        {
            this.context = context;
        }

        public List<Country> GetAll()
        {
            return this.context.Countries.ToList();
        }
    }
}
