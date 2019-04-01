using EventManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Services.Contracts
{
    public interface ICityService
    {
        int CreateCity(string cityName, string countryCode);

        int GetCityIdByName(string cityName);
    }
}
