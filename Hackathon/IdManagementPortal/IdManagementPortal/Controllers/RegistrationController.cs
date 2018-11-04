using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using IdManagementPortal.BlockChainAccess;
using IdManagementPortal.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Neo.Lux.Core;

namespace IdManagementPortal.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View(new RegisterPersonViewModel());
        }

        public async Task<IActionResult> Register(RegisterPersonViewModel vm)
        {
            var img = vm.Photo;


            if (img == null || img.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(@"C:\PictureStorage",
                $"{vm.PassportNumber}.jpg");

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await img.CopyToAsync(stream);
            }

            var blockChainHelper =
                new BlockChainHelper("1dd37fba80fec4e6a6f13fd708d8dcb3b29def768017052f6c930fa1c5d90bbb",
                    "0x941d5591f6d74f0c9d129777a6bae1c385a0373b", NeoRPC.ForPrivateNet());
            img.GetHashCode().ToString();
            blockChainHelper.PostSomeStuffToAContract("save", new object[] { vm.PassportNumber, Path.GetFileName(path), img.GetHashCode().ToString(), vm.FullName, vm.Address, vm.Citizen });


            return RedirectToAction("Index");
        }
    }
}