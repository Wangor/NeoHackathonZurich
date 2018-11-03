using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using WebPlatform.DataAccess.Entities;

namespace WebPlatform.DataAccess.Repositories
{
    public class TicketCategoryRepository
    {
        private readonly IDbConnection _connection;

        public TicketCategoryRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public void Add(TicketCategoryEntity entity)
        {
            var sql = @"INSERT INTO [dbo].[TicketCategory]
                           ([TicketCategoryId]
                           ,[EventId]
                           ,[Name]
                           ,[Price]
                           ,[Currency]
                           ,[NumberOfTickets])
                     VALUES
                           (@TicketCategoryId
                           ,@EventId
                           ,@Name
                           ,@Price

                           ,@Currency
                           ,@NumberOfTickets)";
            _connection.Execute(sql, entity);
        }

        public IEnumerable<TicketCategoryEntity> GetTicketCategoriesForEvent(Guid eventId)
        {
            return _connection.Query<TicketCategoryEntity>("SELECT * FROM TicketCategory WHERE EventId=@EventId",
                new {EventId = eventId});
        }

        public TicketCategoryEntity GetCategory(Guid categoryId)
        {
            return _connection.QueryFirst<TicketCategoryEntity>("SELECT * FROM TicketCategory WHERE TicketCategoryId=@TicketCategoryId",
                new { TicketCategoryId = categoryId });
        }
    }
}
