namespace IdentityService.Domain.Services;

public interface IPasswordService
{
    public byte[] HashPassword(string password, byte[] salt);
    
    public byte[] CreateSaltedHash();
    
    public bool VerifyHashedPassword(string password, byte[] salt, byte[] hashedPassword);
}