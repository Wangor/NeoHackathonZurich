using System.Collections.Generic;
using System.Linq;

namespace WebPlatform.DataAccess.Repositories
{
    public class TicketRepository
    {
        private IList<TicketEntity> _tickets;

        public TicketRepository()
        {
            _tickets = new List<TicketEntity>
            {
                new TicketEntity {OwnerId = "123", TicketId = "ABC"},
                new TicketEntity {OwnerId = "123", TicketId = "CDF"},
                new TicketEntity {OwnerId = "123", TicketId = "XYZ"},
                new TicketEntity {OwnerId = "456", TicketId = "ZZZ"},
                new TicketEntity {OwnerId = "456", TicketId = "WER"}
            };

        }

        public IEnumerable<TicketEntity> All()
        {
            return _tickets;
        }

        public IEnumerable<TicketEntity> GetByOwner(string ownerId)
        {
            return _tickets.Where(_ => _.OwnerId == ownerId);
        }

        public void Add(TicketEntity ticket)
        {
            _tickets.Add(ticket);
        }

        public void Delete(string ticketId)
        {
            _tickets.Remove(_tickets.FirstOrDefault(_ => _.TicketId == ticketId));
        }

        
    }
}
