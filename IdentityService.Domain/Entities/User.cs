using IdentityService.Domain.ValueObjects;
using IdentityService.SharedKernal;

namespace IdentityService.Domain.Entities;

public class User : Entity<UserId>
{
    public UserId Id { get; private set; }
    public string UserName { get; private set; }
    public PasswordHash  PasswordHash { get; private set; }
    public string Email { get; private set; }

    private User(UserId id, string userName, PasswordHash passwordHash, string email)
    {
        Id = id;
        UserName = userName;
        PasswordHash = passwordHash;
        Email = email;
    }

    public static User Create(string userName, PasswordHash passwordHash, string email)
    {
        return new User(new UserId(Guid.NewGuid()), userName, passwordHash, email);
    }
}

public record UserId(Guid Id);