using System;
using System.Collections.Generic;
using System.Text;

namespace WebPlatform.DataAccess.Entities
{
    public class EventEntity
    {
        public Guid EventId { get; set; }

        public string EventName { get; set; }

        public string SmartContractId { get; set; }

        public string EventDescription { get; set; }

        public  DateTime EventDateTime { get; set; }

        public  Guid OrganizerId { get; set; }
    }
}
