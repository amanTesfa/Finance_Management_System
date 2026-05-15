using System.Security.Cryptography;
using System.Text;

namespace Finance_Management_System.Helpers
{
    public class AuthenticationHelpers
    {
        public static void CreatePasswordHash(
         string password,
         out string hash,
         out string salt)
        {
            using var hmac = new HMACSHA512();

            salt = Convert.ToBase64String(hmac.Key);

            hash = Convert.ToBase64String(
                hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        public static bool VerifyPassword(
            string password,
            string storedHash,
            string storedSalt)
        {
            var saltBytes = Convert.FromBase64String(storedSalt);

            using var hmac = new HMACSHA512(saltBytes);

            var computedHash = Convert.ToBase64String(
                hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));

            return computedHash == storedHash;
        }
    }
}
