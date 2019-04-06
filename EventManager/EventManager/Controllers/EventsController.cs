using EventManager.Data;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using EventManager.ViewModels.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace EventManager.Controllers
{
    //The class where can create, showe and edite Event
    /// <summary>
    /// The class where can create, showe and edite Event
    /// </summary>
    public class EventsController : Controller
    {
        private IEventService eventService;

        private ICountryService countriesService;

        private EventManagerDbContext context;

        //Events Controller Constructor, sets Services and DbContext:
        public EventsController(IEventService eventService, ICountryService countriesService, EventManagerDbContext context)
        {
            this.eventService = eventService;
            this.countriesService = countriesService;
            this.context = context;
        }

        //Return all events
        /// <summary>
        /// Return all events
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var model = eventService.GetAllEvents();

            return View(model);
        }

        //Creates EventView for Front End:
        /// <summary>
        /// Creates EventView for Front End:
        /// </summary>
        /// <returns></returns>
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

        //Read information about the event and creates it:
        /// <summary>
        /// Read information about the event and creates it:
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="date"></param>
        /// <param name="description"></param>
        /// <param name="link"></param>
        /// <param name="addressViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(string eventName, DateTime date, string description, string link,
            CreateAddressViewModel addressViewModel)
        {
            if (IsEventCreateStatementAreValid(eventName, date, addressViewModel))
            {
                throw new InvalidOperationException("Please, enter information at EventName, AddressName, CityName and Date fields!");
            }

            eventService.CreateEvent(eventName, date, description, link, addressViewModel);
            return RedirectToAction("Index", "Events", new { area = "" });
        }

        //Returns Details to current Event
        /// <summary>
        /// Returns Details to current Event
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            var model = eventService.GetEventDetails(id);

            return View(model);
        }

        //Returns the ViewModel for "Edit" window:
        /// <summary>
        /// Returns the ViewModel for "Edit" window:
        /// </summary>
        /// <returns></returns>
        public IActionResult Edit()
        {
            var editEventViewModel = new EditEventViewModel();

            return View(editEventViewModel);
        }

        //Performs the Edit button actions:
        /// <summary>
        /// /Performs the Edit button actions:
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Edit")]
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
               e => e.Link)
               || await TryUpdateModelAsync<Event>(
                eventToUpdate,
               "",
                e => e.Description))
            {
                try
                {
                    await context.SaveChangesAsync();
                    return RedirectToAction("Index", "Events", new { area = "" });
                }
                catch (DbUpdateException)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            else
            {
                string exmsg = "";

                try
                {
                    throw new InvalidOperationException("Please, enter information at all four fields!");
                }
                catch (InvalidOperationException ex)
                {
                    exmsg = ex.Message;
                }

                return RedirectToAction("FileUpload", "Controllername", new { errormsg = exmsg });
            }

            return View(eventToUpdate);
        }

        //Show Error from Edit
        /// <summary>
        /// Show Error from Edit
        /// </summary>
        /// <param name="errormsg"></param>
        /// <returns></returns>
        [HttpGet]
        public ActionResult FileUpload(string errormsg)
        {
           ViewBag.Error = errormsg;
           return View(errormsg);
        }

        //Private Methods:
        /// <summary>
        /// Check
        /// </summary>
        /// <param name="eventName"></param>
        /// <param name="date"></param>
        /// <param name="addressViewModel"></param>
        /// <returns></returns>
        private bool IsEventCreateStatementAreValid(string eventName, DateTime date, CreateAddressViewModel addressViewModel)
        {
            if (eventName == null || date == null || addressViewModel == null)
            {
                return true;
            }

            return false;
        }
    }
}