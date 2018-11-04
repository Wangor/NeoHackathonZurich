using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Neo.Lux.Core;
using Neo.Lux.Cryptography;
using Neo.Lux.Utils;

namespace IdManagementPortal.BlockChainAccess
{
    public class BlockChainHelper
    {
        private byte[] _privateKey;
        private NeoRPC _api;
        private string _contractScriptHash;
        private UInt256 _lastTransactionHash;

        public BlockChainHelper(string privateKey, string contractScriptHash, NeoRPC api)
        {
            _privateKey = privateKey.HexToBytes();
            _contractScriptHash = contractScriptHash;
            _api = api;
        }

        public void PostSomeStuffToAContract(string operation, object[] parameters, bool waitForTransactionFinished = true)
        {

            var myKeys = new KeyPair(_privateKey);
            var scriptHash = UInt160.Parse(_contractScriptHash);

            Transaction result = null;

            while (result == null)
            {
                result = _api.CallContract(myKeys, scriptHash, operation, parameters);
                if (result == null) Thread.Sleep(500);
            }

            _lastTransactionHash = result.Hash;
            if (waitForTransactionFinished) _api.WaitForTransaction(new BlockIterator(_api), Filter, 10);
        }

        private bool Filter(Transaction arg)
        {
            return arg.Hash == _lastTransactionHash;
        }

        public string JustGetSomeStuffFromAContractAsString(string operation, object[] parameters)
        {
            var scriptHash = UInt160.Parse(_contractScriptHash);
            var invokeResult = _api.InvokeScript(scriptHash, operation, parameters);

            return invokeResult.result.GetString();
        }
    }
}
