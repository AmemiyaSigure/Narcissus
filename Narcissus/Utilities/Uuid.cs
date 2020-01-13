using System;
using System.Security.Cryptography;

namespace Narcissus.Utilities
{
    public class Uuid
    {
        public static string GetUuid()
        {
            return Guid.NewGuid().ToString("N");
        }

        public static string GetUuid(byte[] bytes)
        {
            MD5 md5 = MD5.Create();
            byte[] hash = md5.ComputeHash(bytes);
            hash[6] &= 0x0f;
            hash[6] |= 0x30;
            hash[8] &= 0x3f;
            hash[8] |= 0x80;
            return BitConverter.ToString(hash).Replace("-", string.Empty).ToLower();
        }

        public static string ToUnsignedUuid(string SignedUuid)
        {
            Guid guid = new Guid();
            Guid.TryParse(SignedUuid, out guid);
            return guid.ToString("N");
        }

        public static string ToSignedUuid(string UnsignedUuid)
        {
            Guid guid = new Guid();
            Guid.TryParse(UnsignedUuid, out guid);
            return guid.ToString("D");
        }
    }
}
