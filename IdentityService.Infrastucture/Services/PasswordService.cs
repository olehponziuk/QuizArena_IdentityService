using System.Security.Cryptography;
using System.Text;
using IdentityService.Domain.Services;
using Konscious.Security.Cryptography;

namespace IdentityService.Infrastucture.Services;

public class PasswordService : IPasswordService
{
    
    private int DegreeOfParallelism = 32;
    private int Iterations = 1000;
    private int MemorySize = 256;
        
    public byte[] HashPassword(string password, byte[] salt)
    {
        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = DegreeOfParallelism;
        argon2.Iterations = Iterations;
        argon2.MemorySize = MemorySize;
        
        return argon2.GetBytes(64);
    }

    public byte[] CreateSaltedHash()
    {
        return RandomNumberGenerator.GetBytes(16);
    }

    public bool VerifyHashedPassword(string password, byte[] salt, byte[] hashedPassword)
    {
        using var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password));
        argon2.Salt = salt;
        argon2.DegreeOfParallelism = DegreeOfParallelism;
        argon2.Iterations = Iterations;
        argon2.MemorySize = MemorySize;
        
        byte[] tmpHash = argon2.GetBytes(64);
        
        return CryptographicOperations.FixedTimeEquals(hashedPassword, tmpHash);
    }
}