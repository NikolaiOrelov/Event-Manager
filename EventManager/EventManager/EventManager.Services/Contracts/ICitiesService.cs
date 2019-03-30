using EventManager.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Services.Contracts
{
    public interface ICitiesService
    {
        uint CreateCity(string name, string countryCode);

        uint GetIdByName(string name);
    }
}
