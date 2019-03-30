using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Create(string name, string CountyCode)
        {
            ;
            citiesService.CreateCity(name, CountyCode);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}