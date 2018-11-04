using Microsoft.AspNetCore.Http;

namespace IdManagementPortal.ViewModels
{
    public class RegisterPersonViewModel
    {
        public string PassportNumber { get; set; }

        public string FullName { get; set; }

        public string Address { get; set; }

        public string Citizen { get; set; }

        public IFormFile Photo { set; get; }

    }
}
