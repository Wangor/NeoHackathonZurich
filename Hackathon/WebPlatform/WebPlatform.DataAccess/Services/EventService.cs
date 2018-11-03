using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using WebPlatform.DataAccess.Entities;
using WebPlatform.DataAccess.Repositories;
using WebPlatform.DataAccess.ViewModels;

namespace WebPlatform.DataAccess.Services
{
    public class EventService
    {
        private readonly IDbConnection _connection;
        private readonly EventRepository _eventRepository;
        private readonly TicketCategoryRepository _ticketCategoryRepository;

        public EventService(IDbConnection connection, EventRepository eventRepository, TicketCategoryRepository ticketCategoryRepository)
        {
            _connection = connection;
            _eventRepository = eventRepository;
            _ticketCategoryRepository = ticketCategoryRepository;
        }

        public IEnumerable<EventViewModel> GetEventsForUser(Guid userId)
        {
            var result = _connection.Query<EventViewModel>("SELECT * FROM Events WHERE OrganizerId=@OwnerId",
                new { OwnerId = userId });
            return result;
        }

        public void AddNewEvent(NewEventViewModel vm)
        {
            var entity = new EventEntity
            {
                EventName = vm.EventName,
                SmartContractId = vm.SmartContractId,
                EventId = Guid.NewGuid(),
                EventDescription = vm.Description,
                EventDateTime = vm.EventDateTime,
                OrganizerId = vm.OwnerId
            };

            _eventRepository.Add(entity);
        }

        public EventViewModel GetEventById(Guid eventId)
        {
            var eventDetails = _eventRepository.GetById(eventId);

            var result = new EventViewModel
            {
                EventId = eventDetails.EventId,
                EventName = eventDetails.EventName,
                EventDateTime = eventDetails.EventDateTime
            };


            return result;
        }

        public Guid GetEventOwner(Guid eventId)
        {
            return _connection.QueryFirst<Guid>("SELECT OrganizerId FROM Events WHERE EventId=@EventId",
                new {EventId = eventId});
        }

        public IEnumerable<TicketCategoryViewModel> GetCategoriesForEvent(Guid eventId)
        {
            var categories = _ticketCategoryRepository.GetTicketCategoriesForEvent(eventId);

            return categories.Select(ticketCategoryEntity => new TicketCategoryViewModel
                {
                    Name = ticketCategoryEntity.Name,
                    Price = ticketCategoryEntity.Price,
                    Currency = ticketCategoryEntity.Currency,
                    NumberOfTickets = ticketCategoryEntity.NumberOfTickets,
                    TicketCategoryId = ticketCategoryEntity.TicketCategoryId,
                    EventId = ticketCategoryEntity.EventId
                })
                .ToList();
        }
    }
}
