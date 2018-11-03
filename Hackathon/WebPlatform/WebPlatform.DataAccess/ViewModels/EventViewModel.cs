using System;
using System.Collections.Generic;
using System.Text;

namespace WebPlatform.DataAccess.ViewModels
{
    public class EventViewModel
    {
        public Guid EventId { get; set; }

        public string EventName { get; set; }

        public DateTime EventDateTime { get; set; }

        public string Description { get; set; }
    }
}
