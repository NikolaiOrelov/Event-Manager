using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    public class AddressesController : Controller
    {
        private IAddressService addressesService;

        private ICountryService countriesService;


        public AddressesController(IAddressService addressesService, ICountryService countriesService)
        {
            this.addressesService = addressesService;
            this.countriesService = countriesService;
        }

        public IActionResult Create()
        {
            var cityViewModel = new CreateCityViewModel
            {
                Countries = countriesService.GetAll()
            };

            var addressViewModel = new CreateAddressViewModel() { CityViewModel = cityViewModel };

            return View(addressViewModel);
        }

        [HttpPost]
        public IActionResult Create(string addressName, CreateCityViewModel cityViewModel)
        {
            addressesService.CreateAddress(addressName, cityViewModel);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}