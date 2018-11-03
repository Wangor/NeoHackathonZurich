using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using WebPlatform.DataAccess.Entities;

namespace WebPlatform.DataAccess.Repositories
{
    public class EventRepository
    {
        private readonly IDbConnection _connection;

        public EventRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IList<EventEntity> All()
        {
            return new List<EventEntity>();
        }

        public void Add(EventEntity entity)
        {
            var sql = @"INSERT INTO [Events]
           ([EventId]
           ,[EventName]
           ,[SmartContractId]
           ,[EventDescription]
           ,[EventDateTime]
           ,[OrganizerId])
     VALUES
           (@EventId
           ,@EventName
           ,@SmartContractId
           ,@EventDescription
           ,@EventDateTime
           ,@OrganizerId)";
            _connection.Execute(sql, entity);
        }

        public EventEntity GetById(Guid eventId)
        {
            return _connection.QueryFirstOrDefault<EventEntity>("SELECT * FROM Events where EventId=@EventId", new {EventId = eventId});
        }
    }
}
