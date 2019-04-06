using EventManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    //The class whaere current user saves here events
    /// <summary>
    /// The class whaere current user saves here events
    /// </summary>
    public class EventListsController : Controller
    {
        private IEventListService eventListService;

        public EventListsController(IEventListService eventListService)
        {
            this.eventListService = eventListService;
        }

        //Added Event to List
        /// <summary>
        /// Added Event to List
        /// </summary>
        public IActionResult AddToList(int id)
        {
            eventListService.AddEvent(id, User.Identity.Name);

            return RedirectToAction("Index", "Events", new { area = "" });
        }

        //Return all Events in EventList to current User
        /// <summary>
        /// Return all Events in EventList to current User
        /// </summary>
        public IActionResult Index()
        {
            var model = eventListService.GetAllEvents(User.Identity.Name);

            return View(model);
        }

        //Remove event from EventList
        /// <summary>
        /// Remove event from EventList
        /// </summary>
        public IActionResult Remove(int eventId)
        {
            eventListService.RemoveEvent(eventId, User.Identity.Name);

            return RedirectToAction("Index", "EventLists", new { area = "" });
        }
    }
}