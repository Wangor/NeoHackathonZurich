using System;

namespace WebPlatform.DataAccess
{
    public class TicketEntity
    {
        public string TicketId { get; set; }

        public Guid EventId { get; set; }

        public string OwnerId { get; set; }
    }
}
