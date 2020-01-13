using System.Security.Cryptography;
using System.Text;

namespace Narcissus.Utilities
{
    public class Password
    {
        public static string HashPassword(string password, string salt)
        {
            return Sha512(Md5(salt) + Sha512(password));
        }

        private static string Md5(string str)
        {
            using (var md5 = MD5.Create())
            {
                var result = "";
                var buffer = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
                for (int i = 0; i < buffer.Length; i++)
                {
                    result += buffer[i].ToString("X2");
                }
                return result.ToLower();
            }
        }

        private static string Sha512(string str)
        {
            using (var sha512 = SHA512.Create())
            {
                var result = "";
                var buffer = sha512.ComputeHash(Encoding.UTF8.GetBytes(str));
                for (int i = 0; i < buffer.Length; i++)
                {
                    result += buffer[i].ToString("X2");
                }
                return result.ToLower();
            }
        }
    }
}
