using System.Security.Cryptography;
using System.Text;

namespace CrudApp.Helper
{
    public static class Criptografia
    {
        public static string GerarHash(string senha, string salt)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] saltBytes = Convert.FromBase64String(salt);
                byte[] senhaBytes = Encoding.UTF8.GetBytes(senha);

                // Mesclar salt com a senha
                byte[] senhaComSalt = new byte[saltBytes.Length + senhaBytes.Length];
                Array.Copy(saltBytes, senhaComSalt, saltBytes.Length);
                Array.Copy(senhaBytes, 0, senhaComSalt, saltBytes.Length, senhaBytes.Length);

                // Calcula o hash SHA-1
                byte[] hashBytes = sha1.ComputeHash(senhaComSalt);

                // Converte o hash em uma representação hexadecimal
                StringBuilder hexStringBuilder = new StringBuilder();
                foreach (byte hashByte in hashBytes)
                {
                    hexStringBuilder.Append(hashByte.ToString("x2"));
                }

                return hexStringBuilder.ToString();
            }
        }


        public static string GerarSalt()
        {
            byte[] saltBytes = new byte[16];
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}
