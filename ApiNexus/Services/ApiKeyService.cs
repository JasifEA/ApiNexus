using System.Security.Cryptography;
using System.Text;

namespace ApiNexus.Services
{
    public class ApiKeyService
    {
        public string GenerateApiKey()
        {
            var keyBytes = new byte[32];
            RandomNumberGenerator.Fill(keyBytes);
            return Convert.ToBase64String(keyBytes);
        }
        public string HashApiKey(string apiKey)
        {
            using var sha256 = SHA256.Create();
            var hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(apiKey));
            return Convert.ToBase64String(hashBytes);
        }
    }
}
