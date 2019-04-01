using EventManager.ViewModels.Models;

namespace EventManager.Services.Contracts
{
    public interface IAddressService
    {
        int CreateAddress(string addressName, CreateCityViewModel cityViewModel);

        int GetAddressIdByName(string addressName);
    }
}
