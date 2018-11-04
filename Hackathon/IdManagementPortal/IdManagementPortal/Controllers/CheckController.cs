using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdManagementPortal.BlockChainAccess;
using IdManagementPortal.Services;
using IdManagementPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Neo.Lux.Core;

namespace IdManagementPortal.Controllers
{
    public class CheckController : Controller
    {
        private readonly PersonInfoService _personInfoService;

        public CheckController(PersonInfoService personInfoService)
        {
            _personInfoService = personInfoService;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Check(CheckPassportViewModel vm)
        {
            var personInfo = _personInfoService.GetPersonInfo(vm.PassportNumber);
            return View(personInfo);
        }
    }
}