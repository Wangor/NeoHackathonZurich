using System;
using System.Collections.Generic;
using System.Text;

namespace WebPlatform.DataAccess.ViewModels
{
    public class EventDetailsViewModel
    {
        public EventDetailsViewModel()
        {
            TicketCategories = new List<TicketCategoryViewModel>();
        }

        public EventViewModel EventDetails { get; set; }

        public IEnumerable<TicketCategoryViewModel> TicketCategories { get; set; }
    }
}
