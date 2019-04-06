using EventManager.ViewModels.Models;

namespace EventManager.Services.Contracts
{
    public interface IAddressService
    {
        //Create address and City if need
        /// <summary>
        /// Create address and City if need
        /// </summary>
        /// <param name="addressName"></param>
        /// <param name="cityViewModel"></param>
        /// <returns>Current created AddressId</returns>
        int CreateAddress(string addressName, CreateCityViewModel cityViewModel);

        //Find address by name
        /// <summary>
        /// Find address by name
        /// </summary>
        /// <param name="addressName"></param>
        /// <returns>AddressId</returns>
        int GetAddressIdByName(string addressName);
    }
}
