using System.Text.RegularExpressions;

namespace Infra.Utils
{
    public static class PasswordUtils
    {
        public static bool IsValidPassword(string password)
        {
            string pattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$";

            if (Regex.IsMatch(password, pattern))
            {
               return true;
            }
           return false;
        }
    }
}
