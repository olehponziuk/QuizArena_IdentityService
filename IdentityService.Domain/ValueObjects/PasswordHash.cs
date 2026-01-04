using IdentityService.Domain.Exceptions;

namespace IdentityService.Domain.ValueObjects;

public sealed class PasswordHash
{
    public byte[] Value { get; init; }
    public byte[] Salt { get; init; }
    
    private PasswordHash(byte[] value, byte[] salt)
    {
        Value = value;
        Salt = salt;
    }

    public static PasswordHash Create(byte[] value, byte[] salt)
    {
        if (value.Length == 0 || salt.Length == 0)
        {
            throw new BadPasswordHashException("PasswordHash: value.Length == 0 || salt.Length == 0");
        }
        
        return new PasswordHash(value, salt);
    }

    
    
}