using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IdManagementPortal.BlockChainAccess;
using IdManagementPortal.ViewModels;
using Neo.Lux.Core;

namespace IdManagementPortal.Services
{
    public class PersonInfoService
    {
        public PersonInfoDto GetPersonInfo(string passportNumber)
        {
            var personInfo = new PersonInfoDto();

            var blockChainHelper =
                new BlockChainHelper("1dd37fba80fec4e6a6f13fd708d8dcb3b29def768017052f6c930fa1c5d90bbb",
                    "0x941d5591f6d74f0c9d129777a6bae1c385a0373b", NeoRPC.ForPrivateNet());

            personInfo.PictureDownloadUrl = blockChainHelper.JustGetSomeStuffFromAContractAsString("getImgUrl", new object[] { passportNumber });
            personInfo.Fullname = blockChainHelper.JustGetSomeStuffFromAContractAsString("getName", new object[] { passportNumber });
            personInfo.Address = blockChainHelper.JustGetSomeStuffFromAContractAsString("getAddress", new object[] { passportNumber });
            personInfo.Citizen = blockChainHelper.JustGetSomeStuffFromAContractAsString("getCitizenship", new object[] { passportNumber });
            personInfo.PictureHash = blockChainHelper.JustGetSomeStuffFromAContractAsString("getImgHash", new object[] { passportNumber });
            personInfo.PassportNumber = passportNumber;

            return personInfo;
        }
    }
}
