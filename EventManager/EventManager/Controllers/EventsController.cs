using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Controllers
{
    public class EventsController : Controller
    {
        private IEventService eventService;

        private ICountryService countriesService;

        private EventManagerDbContext context;


        public EventsController(IEventService eventService, ICountryService countriesService, EventManagerDbContext context)
        {
            this.eventService = eventService;
            this.countriesService = countriesService;
            this.context = context;
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
            return RedirectToAction("Index", "Events", new { area = "" });
        }

        public IActionResult Details(int id)
        {
            var model = eventService.GetEventDetails(id);

            return View(model);
        }

        public IActionResult Edit()
        {
            var editEventViewModel = new EditEventViewModel();

            return View(editEventViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventToUpdate = await context.Events.FirstOrDefaultAsync(e => e.Id == id);

            if (await TryUpdateModelAsync<Event>(
                eventToUpdate,
                "",
                e => e.EventName,
                e => e.Date,
                e => e.Description,
                e => e.Link))
            {
                try
                {
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index", "Events", new { area = "" });
                }
                catch (DbUpdateException ex)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(eventToUpdate);
        }

        public IActionResult Index()
        {
            var model = eventService.GetAllEvents();

            return this.View(model);
        }
    }
}