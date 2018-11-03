using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using WebPlatform.DataAccess.Repositories;
using WebPlatform.DataAccess.ViewModels;

namespace WebPlatform.DataAccess.Services
{
    /// <exclude />
    public class TicketService
    {
        private readonly TicketRepository _ticketRepository;
        private readonly IDbConnection _connection;

        public TicketService(TicketRepository ticketRepository, IDbConnection connection)
        {
            _ticketRepository = ticketRepository;
            _connection = connection;
        }

        public IEnumerable<TicketViewModel> GetTicketsForEvent(Guid eventId)
        {
            var result = new List<TicketViewModel>();

            _connection.Query<TicketViewModel>("SELECT * FROM ");

                return result;
        }
    }
}
