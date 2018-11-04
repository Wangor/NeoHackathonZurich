using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;

namespace BrandItemContract
{
    public class Contract1 : SmartContract
    {
        public static object Main(string operation, params object[] args)
        {
            switch (operation)
            {
                case "registerItem":
                    return RegisterItem((string)args[0], (byte[])args[1]);
                    break;
                case "getOwner":
                    return GetOwner((string)args[0]);
                    break;
                case "transferOwnership":
                    return TransferOwnerShip((string) args[0], (byte[]) args[1]);
            }

            return false;
        }

        private static object TransferOwnerShip(string identity, byte[] to)
        {
            if (!Runtime.CheckWitness(to)) return false;
            byte[] from = Storage.Get(Storage.CurrentContext, identity);
            if (from == null) return false;
            if (!Runtime.CheckWitness(from)) return false;
            Storage.Put(Storage.CurrentContext, identity, to);
            Runtime.Notify(identity, "transfer", from.AsString(), to.AsString());
            return true;
        }

        private static byte[] GetOwner(string identifier)
        {
            byte[] bytes = Storage.Get(Storage.CurrentContext, identifier);

            return bytes;
        }

        private static bool RegisterItem(string identifier, byte[] issuer)
        {
            if (!Runtime.CheckWitness(issuer)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, identifier);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, identifier, issuer);
            Runtime.Notify(identifier, "New owner", issuer.AsString());
            return true;
        }
    }

    

    
}
