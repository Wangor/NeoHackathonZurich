using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using WebPlatform.DataAccess.Entities;
using WebPlatform.DataAccess.Repositories;
using WebPlatform.DataAccess.ViewModels;

namespace WebPlatform.DataAccess.Services
{
    public class EventService
    {
        private readonly IDbConnection _connection;
        private readonly EventRepository _eventRepository;

        public EventService(IDbConnection connection, EventRepository eventRepository)
        {
            _connection = connection;
            _eventRepository = eventRepository;
        }

        public IEnumerable<EventViewModel> GetEventsForUser(Guid userId)
        {
            return _connection.Query<EventViewModel>("SELECT * FROM Events WHERE OrganizerId=@OwnerId",
                new {OwnerId = userId});
        }

        public void AddNewEvent(NewEventViewModel vm)
        {
            var entity = new EventEntity
            {
                EventName = vm.EventName,
                SmartContractId = vm.SmartContractId,
                EventId = new Guid(),
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
    }
}
