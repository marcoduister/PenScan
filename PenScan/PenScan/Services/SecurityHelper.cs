using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace PenScan.Services
{
    public class SecurityHelper
    {
        public static string GenerateSalt(int NumberSalt)
        {
            var saltBytes = new byte[NumberSalt];

            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetNonZeroBytes(saltBytes);
            }

            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt, int nIterations, int NumberHash)
        {
            var saltBytes = Convert.FromBase64String(salt);

            using (var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, saltBytes, nIterations))
            {
                return Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(NumberHash));
            }
        }
    }
}
