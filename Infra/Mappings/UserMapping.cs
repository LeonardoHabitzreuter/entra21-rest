using Domain.Common;
using Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infra.Mappings
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var crypt = new Crypt();
            var cryptPassword = crypt.CreateMD5("123");

            builder.HasData(new User(
                "Sys Admin",
                cryptPassword,
                "sysadmin@company.com",
                UserProfile.CBF
            ));

            builder
                .Property(user => user.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(user => user.Email)
                .IsRequired()
                .HasMaxLength(250);

            builder
                .Property(user => user.Password)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .HasIndex(user => user.Email)
                .IsUnique();
        }
    }
}