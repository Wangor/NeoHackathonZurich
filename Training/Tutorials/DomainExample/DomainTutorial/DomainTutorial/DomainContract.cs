﻿using Neo.SmartContract.Framework;
using Neo.SmartContract.Framework.Services.Neo;
using System;
using System.Numerics;

namespace DomainTutorial
{
    public class DomainContract : SmartContract
    {
        public static object Main(string operation, params object[] args)
        {
            switch (operation)
            {
                case "query":
                    return Query((string)args[0]);
                case "register":
                    return Register((string)args[0], (byte[])args[1]);
                case "transfer":
                    return Transfer((string)args[0], (byte[])args[1]);
                case "delete":
                    return Delete((string)args[0]);
                default:
                    return false;
            }
        }

        private static byte[] Query(string domain)
        {
            return Storage.Get(Storage.CurrentContext, domain);
        }

        private static bool Register(string domain, byte[] owner)
        {
            if (!Runtime.CheckWitness(owner)) return false;
            byte[] value = Storage.Get(Storage.CurrentContext, domain);
            if (value != null) return false;
            Storage.Put(Storage.CurrentContext, domain, owner);
            Runtime.Notify(domain, "New owner", owner.AsString());
            return true;
        }

        private static bool Transfer(string domain, byte[] to)
        {
            if (!Runtime.CheckWitness(to)) return false;
            byte[] from = Storage.Get(Storage.CurrentContext, domain);
            if (from == null) return false;
            if (!Runtime.CheckWitness(from)) return false;
            Storage.Put(Storage.CurrentContext, domain, to);
            Runtime.Notify(domain, "transfer", from.AsString(), to.AsString());
            return true;
        }

        private static bool Delete(string domain)
        {
            byte[] owner = Storage.Get(Storage.CurrentContext, domain);
            if (owner == null) return false;
            if (!Runtime.CheckWitness(owner)) return false;
            Storage.Delete(Storage.CurrentContext, domain);
            Runtime.Notify(domain, "deleted");
            return true;
        }
    }
}