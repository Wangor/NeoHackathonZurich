using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;

namespace HelloWorld
{
    public class Contract1 : SmartContract
    {
        public static object Main(string operation, params object[] args)
        {
            Storage.Put(Storage.CurrentContext, operation, (string)args[0]);
            Runtime.Notify(operation, (string)args[0]);
            return true;
        }
    }
}
