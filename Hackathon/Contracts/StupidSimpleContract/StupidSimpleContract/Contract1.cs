using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;

namespace StupidSimpleContract
{
    public class Contract1 : SmartContract
    {
        public static object Main(string operation, params object[] args)
        {
            switch (operation)
            {
                case "staticReturnString":
                    return "Test";
                case "staticReturnInt":
                    return 1;
                case "putKeyValue":
                    Storage.Put(Storage.CurrentContext, (string) args[0], (byte[])args[1]);
                    return 1;
                case "getKeyValue":
                    return Storage.Get(Storage.CurrentContext, (string)args[0]);
            }

            return true;
        }
    }
}
