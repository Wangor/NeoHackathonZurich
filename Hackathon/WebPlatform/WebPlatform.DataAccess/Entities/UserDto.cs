using System;
using System.Collections.Generic;
using System.Text;

namespace WebPlatform.DataAccess.Entities
{
    public class UserDto
    {
        public Guid UserId { get; set; }

        public string PreName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }


    }
}
