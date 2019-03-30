using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace EventManager.Controllers
{
    public class CitiesController : Controller
    {
        private ICitiesService citiesService;
        private ICountriesService countriesService;

        public CitiesController(ICitiesService citiesService, ICountriesService countriesService)
        {
            this.citiesService = citiesService;
            this.countriesService = countriesService;
        }

        public IActionResult Create()
        {
            ;
            var viewModel = new CreateCityViewModel
            {
                Countries = countriesService.GetAll()
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(string name, string countryCode)
        {
            ;
            citiesService.CreateCity(name, countryCode);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}