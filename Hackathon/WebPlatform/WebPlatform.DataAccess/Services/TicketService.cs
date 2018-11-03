using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebPlatform.DataAccess.Entities;
using WebPlatform.DataAccess.Repositories;
using WebPlatform.DataAccess.ViewModels;

namespace WebPlatform.DataAccess.Services
{
    /// <exclude />
    public class TicketService
    {
        private readonly TicketRepository _ticketRepository;
        private readonly TicketCategoryRepository _ticketCategoryRepository;
        private readonly EventService _eventService;
        private readonly UserService _userService;
        private readonly ContractService _contractService;
        private readonly IDbConnection _connection;

        public TicketService(TicketRepository ticketRepository, 
            TicketCategoryRepository ticketCategoryRepository, 
            EventService eventService,
            UserService userService,
            ContractService contractService,
            IDbConnection connection)
        {
            _ticketRepository = ticketRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
            _eventService = eventService;
            _userService = userService;
            _contractService = contractService;
            _connection = connection;
        }

        public IEnumerable<TicketViewModel> GetTicketsForEvent(Guid eventId)
        {
            var result = new List<TicketViewModel>();

            _connection.Query<TicketViewModel>("SELECT * FROM ");

                return result;
        }

        public IEnumerable<TicketViewModel> GetTicketsForTicketCategory(Guid categoryId)
        {
            var category = _ticketCategoryRepository.GetCategory(categoryId);
            var tickets = _ticketRepository.GetTicketsByCategory(categoryId);
            var owner =_eventService.GetEventOwner(category.EventId);
            var ownersAddress = _userService.GetUserPublicAddress(owner);

            var result = new List<TicketViewModel>();
            foreach (var ticketEntity in tickets)
            {
                result.Add(new TicketViewModel
                {
                    TicketId = ticketEntity.TicketId,
                    Sold = ticketEntity.OwnerId != ownersAddress
                });
            }

            return result;
        }

        public void AddTicketCategory(NewTicketCategoryViewModel vm)
        {
            var entity = new TicketCategoryEntity
            {
                Name = vm.Name,
                Price = vm.Price,
                Currency = vm.Currency,
                EventId = vm.EventId,
                TicketCategoryId = Guid.NewGuid()
            };

            _ticketCategoryRepository.Add(entity);

            var organizerId = _eventService.GetEventOwner(vm.EventId);

            for (var i = 0; i < vm.NumberOfTickets; i++)
            {
                var ticket = new TicketEntity
                {
                    TicketId = Guid.NewGuid().ToString(),
                    TicketCategoryId = entity.TicketCategoryId,
                    OwnerId = _userService.GetUserPublicAddress(organizerId)
                };

                _contractService.CreateTicket(ticket.TicketId, _userService.GetUserPublicAddress(organizerId), _userService.GetUserPrivateKey(organizerId));

                _ticketRepository.Add(ticket);
            }
        }

        public IEnumerable<TicketCategoryViewModel> GetTicketCategoriesForEvent(Guid eventId)
        {
            return _connection.Query<TicketCategoryViewModel>("SELECT * FROM TicketCategories WHERE EventId=@EventId",
                new {EventId = eventId});
        }
    }
}
