using IdentityService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IdentityService.Infrastucture.Presistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(u=> u.Id)
            .HasConversion(i => i.Id, value => new UserId(value));
        
        builder.Property(x => x.UserName)
            .HasDefaultValue("Unknown")
            .IsRequired();
        builder.HasIndex(x => x.Email)
            .IsUnique();
    }
}