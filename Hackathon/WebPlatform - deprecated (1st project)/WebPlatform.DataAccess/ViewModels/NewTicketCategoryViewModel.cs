using System;
using System.Collections.Generic;
using System.Text;

namespace WebPlatform.DataAccess.ViewModels
{
    public class NewTicketCategoryViewModel
    {
        public string TicketCategoryId { get; set; }
        public Guid EventId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Currency { get; set; }
        public int NumberOfTickets { get; set; }
    }
}
