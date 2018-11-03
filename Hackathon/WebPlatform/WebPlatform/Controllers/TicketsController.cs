using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using WebPlatform.DataAccess;
using WebPlatform.DataAccess.Services;
using WebPlatform.DataAccess.ViewModels;

namespace WebPlatform.Controllers
{
    public class TicketsController : Controller
    {
        private readonly TicketService _ticketService;
        private readonly IConfiguration _configuration;

        public TicketsController(TicketService ticketService, IConfiguration configuration)
        {
            _ticketService = ticketService;
            _configuration = configuration;
        }

        public IActionResult Index(Guid eventId)
        {
            var ticketsForEvent = _ticketService.GetTicketsForEvent(eventId);
            return View(ticketsForEvent);
        }
    }
}