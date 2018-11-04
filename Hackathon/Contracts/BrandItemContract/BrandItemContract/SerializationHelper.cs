using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace BrandItemContract
{
    public class SerializationHelper
    {

        #region ISerializationHelper ???

        /// <summary>
        /// ?????????????????????
        /// </summary>
        public byte[] Serialize2Bytes(object data)
        {
            if (data == null)
            {
                return new byte[0];
            }
            else
            {
                MemoryStream streamMemory = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(streamMemory, data);
                return streamMemory.GetBuffer();
            }
        }

        /// <summary>
        /// ?????????????????
        /// </summary>
        public object DeserializeFromBytes(byte[] binData)
        {
            if (binData == null)
            {
                return null;
            }
            else
            {
                if (binData.Length == 0)
                {
                    return null;
                }
                else
                {
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream ms = new MemoryStream(binData);
                    return formatter.Deserialize(ms);
                }
            }
        }

        /// <summary>
        /// ?????????????????
        /// </summary>
        public string Serialize2String(object data)
        {
            if (data == null)
            {
                return string.Empty;
            }
            else
            {
                MemoryStream streamMemory = new MemoryStream();
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(streamMemory, data);
                return Convert.ToBase64String(streamMemory.GetBuffer());
            }
        }

        /// <summary>
        /// ?????????????
        /// </summary>
        public object DeserializeFromString(string binString)
        {
            if (binString == null)
            {
                return null;
            }
            else
            {
                if (binString.Length == 0)
                {
                    return null;
                }
                else
                {
                    byte[] binData = Convert.FromBase64String(binString);
                    BinaryFormatter formatter = new BinaryFormatter();
                    MemoryStream ms = new MemoryStream(binData);
                    return formatter.Deserialize(ms);
                }
            }
        }

        #endregion
    }
}
