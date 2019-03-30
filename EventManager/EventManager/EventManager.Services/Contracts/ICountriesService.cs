using EventManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Services.Contracts
{
    public interface ICountriesService
    {
        List<Country> GetAll();
    }
}
