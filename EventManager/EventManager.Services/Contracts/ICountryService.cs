using EventManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Services.Contracts
{
    public interface ICountryService
    {
        //Return all countries for drop list
        /// <summary>
        /// Return all countries for drop list
        /// </summary>
        /// <returns>Return all countries for drop list</returns>
        List<Country> GetAll();
    }
}
