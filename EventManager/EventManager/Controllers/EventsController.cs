using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EventManager.Controllers
{
    public class EventsController : Controller
    {
        private IEventService eventService;

        private ICountryService countriesService;


        public EventsController(IEventService eventService, ICountryService countriesService)
        {
            this.eventService = eventService;
            this.countriesService = countriesService;
        }

        public IActionResult Create()
        {
            var cityViewModel = new CreateCityViewModel
            {
                Countries = countriesService.GetAll()
            };

            var addressViewModel = new CreateAddressViewModel()
            {
                CityViewModel = cityViewModel
            };

            var eventViewModel = new CreateEventViewModel
            {
                AddressViewModel = addressViewModel
            };

            return View(eventViewModel);
        }

        [HttpPost]
        public IActionResult Create(string eventName, DateTime date, string description, string link,
            CreateAddressViewModel addressViewModel)
        {
            eventService.CreateEvent(eventName, date, description, link, addressViewModel);
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}