using System.Security.Cryptography;
using System.Text;

namespace App
{
    public class Hash
    {
        public static string SHA1(string valor)
        {
            using (var sha1 = new SHA1CryptoServiceProvider())
            {
                var bytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(valor));

                var builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }

                return builder
                    .ToString();
            }
        }
    }
}