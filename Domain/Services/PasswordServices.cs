using System.Security.Cryptography;
using System.Text;

namespace Infra.Services
{
    public static class PasswordServices
    {

        public static bool CheckPassword(string password, string hashPassword)
        {
            var userPasswordHash = ConvertPassword(password);
            return userPasswordHash == hashPassword;
        }

        public static string ConvertPassword(string password)
        {
            byte[] data = Encoding.ASCII.GetBytes(password);
            data = SHA256.Create().ComputeHash(data);
            string hash = Encoding.ASCII.GetString(data);
            return hash;
        }
    }
}
