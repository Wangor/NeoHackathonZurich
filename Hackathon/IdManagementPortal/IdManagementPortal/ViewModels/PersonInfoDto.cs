using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IdManagementPortal.ViewModels
{
    public class PersonInfoDto
    {
        public string PassportNumber { get; set; }

        public string Fullname { get; set; }

        public string Address { get; set; }

        public string Citizen { get; set; }

        public string PictureDownloadUrl { get; set; }

        public string PictureHash { get; set; }
    }
}
