using System;
using System.Collections.Generic;
using System.Text;

namespace EventManager.Services.Contracts
{
    public interface IAddressesService 
    {
        int CreateAddress(string name, string cityName, string countryCode);
    }
}
