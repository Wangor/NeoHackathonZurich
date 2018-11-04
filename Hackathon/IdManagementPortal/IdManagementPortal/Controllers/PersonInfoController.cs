using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using IdManagementPortal.BlockChainAccess;
using IdManagementPortal.Services;
using IdManagementPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Neo.Lux.Core;

namespace IdManagementPortal.Controllers
{
    public class PersonInfoController : Controller
    {
        private readonly PersonInfoService _personInfoService;

        public PersonInfoController(PersonInfoService personInfoService)
        {
            _personInfoService = personInfoService;
        }

        [HttpGet]
        public async Task<IActionResult> GetInfo(string passportNumber)
        {
            var personInfo = _personInfoService.GetPersonInfo(passportNumber);

            return Json(personInfo);
        }
    }
}