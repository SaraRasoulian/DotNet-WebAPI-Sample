using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.ValueObjects;
using Domain.Entities;

namespace Infrastructure.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(x => x.FirstName)
            .HasMaxLength(UserConstants.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.LastName)
            .HasMaxLength(UserConstants.NameMaxLength)
            .IsRequired();

        builder.Property(x => x.UserName)
            .HasMaxLength(UserConstants.UsernameMaxLength)
            .IsRequired();

        builder.HasIndex(x => x.UserName)
                    .IsUnique();

        builder.Property(x => x.Email)
            .HasConversion(
            e => e.Value,
            value => new Email(value))
                    .HasMaxLength(UserConstants.EmailMaxLength)
                    .IsRequired();

        builder.HasIndex(x => x.Email)
                    .IsUnique();

        builder.Property(x => x.Password)
            .HasMaxLength(UserConstants.PasswordMaxLength)
            .IsRequired();

        builder.Property(x => x.PointBalance)
            .IsRequired();
    }
}
