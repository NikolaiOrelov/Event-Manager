using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EventManager.Data.Models;
using EventManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EventManager.Controllers
{
    public class EventListsController : Controller
    {
        private IEventListService eventListService;

        public EventListsController(IEventListService eventListService)
        {
            this.eventListService = eventListService;
        }

        public IActionResult AddToList(int id)
        {
            //var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);

            eventListService.AddEvent(id, this.User.Identity.Name);

            return RedirectToAction("Index", "Events", new { area = "" });
        }
    }
}