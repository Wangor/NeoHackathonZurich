using System;
using System.Collections.Generic;
using System.Text;
using Neo.Lux.Core;
using Neo.Lux.Cryptography;
using Neo.Lux.Utils;

namespace WebPlatform.DataAccess.Services
{
    public class ContractService
    {
        private const string ContractScriptHash = "0xa4e6af094a380a2d0b78e8454e00e8fb8d17f0ed";

        //"1dd37fba80fec4e6a6f13fd708d8dcb3b29def768017052f6c930fa1c5d90bbb"

        public void CreateTicket(string ticketId, string ownerAddress, string callerPrivateKey)
        {
            var privKey = callerPrivateKey.HexToBytes();  // can be any valid private key
            var myKeys = new KeyPair(privKey);
            var scriptHash = UInt160.Parse(ContractScriptHash); // the scriptHash of the smart contract you want to use	
            // for now, contracts must be in the format Main(string operation, object[] args)
            var api = NeoRPC.ForPrivateNet();
            var result = api.CallContract(myKeys, scriptHash, "register", new object[] { ticketId, ownerAddress });
        }
    }
}
