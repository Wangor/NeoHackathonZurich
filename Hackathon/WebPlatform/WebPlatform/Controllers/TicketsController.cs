using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly TransferService _transferService;
        private readonly IConfiguration _configuration;

        public TicketsController(TicketService ticketService, TransferService transferService, IConfiguration configuration)
        {
            _ticketService = ticketService;
            _transferService = transferService;
            _configuration = configuration;
        }

        public IActionResult Index(Guid eventId)
        {
            return View();
        }

        public async Task<IActionResult> CreateTicketCategory(Guid eventId)
        {
            return View(new NewTicketCategoryViewModel{EventId = eventId});
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicketCategory(NewTicketCategoryViewModel vm)
        {
            _ticketService.AddTicketCategory(vm);
            return RedirectToAction("Details", "Event", new {eventId = vm.EventId});
        }

        public async Task<IActionResult> ShowTicketsForEvent(Guid categoryId)
        {
            var vm =_ticketService.GetTicketsForTicketCategory(categoryId);
            return View(vm);
        }

        public async Task<IActionResult> TransferTicket(string ticketId)
        {
            var vm = new TransferTicketViewModel {TicketId = ticketId};
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> TransferTicket(TransferTicketViewModel vm)
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            _transferService.Transfer(vm.TicketId, Guid.Parse(userId), vm.ReceiverEMail);
            return RedirectToAction("Index");
        }
    }
}