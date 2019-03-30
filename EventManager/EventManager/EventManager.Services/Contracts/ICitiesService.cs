using EventManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Services.Contracts
{
    public interface ICitiesService
    {
        int CreateCity(string name, string countryCode);

        int GetIdByName(string name);
    }
}
