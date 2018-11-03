using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebPlatform.DataAccess.Services;
using WebPlatform.DataAccess.ViewModels;

namespace WebPlatform.Controllers
{
    public class EventController : Controller
    {
        private readonly EventService _eventService;

        public EventController(EventService eventService)
        {
            _eventService = eventService;
        }

        public IActionResult Index()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(_eventService.GetEventsForUser(Guid.Parse(userId)));
        }

        public async Task<IActionResult> Create()
        {
            return View(new NewEventViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewEventViewModel vm)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            vm.OwnerId = Guid.Parse(userId);
            _eventService.AddNewEvent(vm);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Details(Guid eventId)
        {
            return View(_eventService.GetEventById(eventId));
        }
    }
}