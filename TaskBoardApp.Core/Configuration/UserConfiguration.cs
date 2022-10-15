using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Core.Data.Models;

namespace TaskBoardApp.Core.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            User guestUser = GetUser();
            PasswordHasher<User> hasher = new PasswordHasher<User>();
            guestUser.PasswordHash = hasher.HashPassword(guestUser, "guest");

            builder.HasData(guestUser);
        }

        private User GetUser()
        {
            return new User
            {
                UserName = "guest",
                NormalizedUserName = "GUEST",
                Email = "guest@mail.com",
                NormalizedEmail = "GUEST@MAIL.COM",
                FirstName = "Zheni",
                LastName = "Koleva"
            };
        }
    }
}
