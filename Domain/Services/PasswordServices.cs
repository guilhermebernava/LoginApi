using System.Security.Cryptography;
using System.Text;

namespace Domain.Services
{
    public static class PasswordServices
    {
        private const string strPermutation = "asdaszx51d5asd2a";
        private const int bytePermutation1 = 0x19;
        private const int bytePermutation2 = 0x59;
        private const int bytePermutation3 = 0x17;
        private const int bytePermutation4 = 0x41;

        public static bool VerifyPassword(string password, string hashPassword)
        {
            if (EncryptPassword(password) == DecryptPassword(hashPassword))
            {
                return true;
            }
            return false;
        }
        public static string EncryptPassword(string strData)
        {
            return Convert.ToBase64String(Encrypt(Encoding.UTF8.GetBytes(strData)));
        }

        private static string DecryptPassword(string strData)
        {
            return Encoding.UTF8.GetString(Decrypt(Convert.FromBase64String(strData)));
        }
        private static byte[] Encrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] {bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                        bytePermutation4
            });

            using (MemoryStream memstream = new MemoryStream())
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = passbytes.GetBytes(aes.KeySize / 8);
                    aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

                    CryptoStream cryptostream = new CryptoStream(memstream,
                    aes.CreateEncryptor(), CryptoStreamMode.Write);
                    cryptostream.Write(strData, 0, strData.Length);
                    cryptostream.Close();
                    return memstream.ToArray();
                }
            }

        }
        private static byte[] Decrypt(byte[] strData)
        {
            PasswordDeriveBytes passbytes =
            new PasswordDeriveBytes(strPermutation,
            new byte[] {bytePermutation1,
                         bytePermutation2,
                         bytePermutation3,
                        bytePermutation4
            });
            using (MemoryStream memstream = new MemoryStream())
            {
                using (var aes = Aes.Create())
                {
                    aes.Key = passbytes.GetBytes(aes.KeySize / 8);
                    aes.IV = passbytes.GetBytes(aes.BlockSize / 8);

                    CryptoStream cryptostream = new CryptoStream(memstream,
                    aes.CreateDecryptor(), CryptoStreamMode.Write);
                    cryptostream.Write(strData, 0, strData.Length);
                    cryptostream.Close();
                    return memstream.ToArray();
                }

            }

        }

    }

}

