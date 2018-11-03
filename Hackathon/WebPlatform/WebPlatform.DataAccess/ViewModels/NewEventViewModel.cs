using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace WebPlatform.DataAccess.ViewModels
{
    public class NewEventViewModel
    {
        public NewEventViewModel()
        {
            EventDateTime = DateTime.Now;
        }

        public string EventName { get; set; }
        public string SmartContractId { get; set; }

        public DateTime EventDateTime { get; set; }

        public Guid OwnerId { get; set; }
        public string Description { get; set; }
    }
}
