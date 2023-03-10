using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarMarket.Core
{
    public static class CarMarketDbContextExtention
    {
        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string USER_ROLE_ID = Guid.NewGuid().ToString();


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                 new IdentityRole
                 {
                     Id = USER_ROLE_ID,
                     Name = "User",
                     NormalizedName = "USER"
                 }
                );

            string ADMIN_ID = Guid.NewGuid().ToString();
            string USER_ID = Guid.NewGuid().ToString();

            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "admin@carmarket.com",
                Email = "admin@carmarket.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@carmarket.com".ToUpper(),
                NormalizedUserName = "admin@carmarket.com".ToUpper()
            };
           
            var user = new User
            {
                Id = USER_ID,
                UserName = "user@carmarket.com",
                Email = "user@carmarket.com",
                EmailConfirmed = true,
                NormalizedEmail = "user@carmarket.com".ToUpper(),
                NormalizedUserName = "user@carmarket.com".ToUpper()
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin$Pass1");       
            user.PasswordHash = hasher.HashPassword(user, "user$Pass1");

            builder.Entity<User>().HasData(admin, user);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = USER_ID
                },                
                new IdentityUserRole<string>
                {
                    RoleId = USER_ROLE_ID,
                    UserId = USER_ID
                });
        }
    }
}
