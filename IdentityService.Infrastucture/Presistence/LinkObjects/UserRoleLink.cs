using IdentityService.Domain.Entities;

namespace IdentityService.Infrastucture.Presistence.LinkObjects;

public class UserRoleLink
{
    public Guid RoleId { get; private set; }
    public Guid UserId { get; private set; }
    private UserRoleLink() { }
    public UserRoleLink(Guid roleId, Guid userId)
    { 
        RoleId = roleId;
        UserId = userId;
    }
    
}