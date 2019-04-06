using EventManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Services.Contracts
{
    public interface ICityService
    {
        //Create City and connect City with her country
        /// <summary>
        /// Create City and connect City with her country
        /// </summary>
        /// <param name="cityName"></param>
        /// <param name="countryCode"></param>
        /// <returns>Current created city</returns>
        int CreateCity(string cityName, string countryCode);

        //Find City id by name
        /// <summary>
        /// Find City id by name
        /// </summary>
        /// <param name="cityName"></param>
        /// <returns>CityId</returns>
        int GetCityIdByName(string cityName);
    }
}
