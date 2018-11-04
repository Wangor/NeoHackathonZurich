using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace WebPlatform.DataAccess.Repositories
{
    public class TicketRepository
    {
        private readonly IDbConnection _connection;
        private IList<TicketEntity> _tickets;

        public TicketRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public IEnumerable<TicketEntity> GetTicketsByCategory(Guid categoryId)
        {
            return _connection.Query<TicketEntity>("SELECT * FROM Tickets WHERE TicketCategoryId=@CategoryId",
                new {CategoryId = categoryId});
        }

        public IEnumerable<TicketEntity> GetByOwner(string ownerId)
        {
            return _tickets.Where(_ => _.OwnerId == ownerId);
        }

        public void Add(TicketEntity entity)
        {
            var sql = @"INSERT INTO [dbo].[Tickets]
                               ([TicketId]
                               ,[TicketCategoryId]
                               ,[OwnerId])
                         VALUES
                               (@TicketId
                               ,@TicketCategoryId
                               ,@OwnerId)";

            _connection.Execute(sql, entity);
        }

        public void Delete(string ticketId)
        {
            _tickets.Remove(_tickets.FirstOrDefault(_ => _.TicketId == ticketId));
        }


        public TicketEntity GetTicketById(string ticketId)
        {
            return _connection.QueryFirstOrDefault<TicketEntity>("SELECT * From Tickets WHERE TicketId=@TicketId",
                new {TicketId = ticketId});
        }

        public void UpdateTicketOwner(string ticketId, string newOwnerAddress)
        {
            _connection.Execute("UPDATE Tickets SET OwnerId=@NewOwnerAddress WHERE TicketId=@TicketId",
                new {NewOwnerAddress = newOwnerAddress, TicketId = ticketId});
        }
    }
}
