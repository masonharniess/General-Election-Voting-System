using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GEVS_API.Services;

public class HashingService
{
    public string HashPassword(string password)
    {
        byte[] salt = new byte[128 / 8];
        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }

        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        
        return $"{Convert.ToBase64String(salt)}.{hashed}";
    }

    public bool VerifyPassword(string hashedPasswordWithSalt, string passwordToCheck)
    {
        var parts = hashedPasswordWithSalt.Split('.', 2);
        if (parts.Length != 2)
        {
            throw new FormatException("The stored password is not in the expected format.");
        }

        var salt = Convert.FromBase64String(parts[0]);
        var storedHash = parts[1];
        
        string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: passwordToCheck,
            salt: salt,
            prf: KeyDerivationPrf.HMACSHA256,
            iterationCount: 100000,
            numBytesRequested: 256 / 8));
        
        return hashed == storedHash;
    }
}
