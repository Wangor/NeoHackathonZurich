using System;

namespace WebPlatform.DataAccess
{
    public class TicketEntity
    {
        public string TicketId { get; set; }

        public Guid TicketCategoryId { get; set; }

        public string OwnerId { get; set; }
    }
}
