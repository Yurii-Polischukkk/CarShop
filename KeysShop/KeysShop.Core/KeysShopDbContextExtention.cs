using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KeysShop.Core
{
    public static class KeysShopDbContextExtention
    {
        public static void Seed(this ModelBuilder builder)
        {
            string ADMIN_ROLE_ID = Guid.NewGuid().ToString();
            string MANAGER_ROLE_ID = Guid.NewGuid().ToString();
            string CUSTOMER_ROLE_ID = Guid.NewGuid().ToString();
            string CONSULTANT_ROLE_ID = Guid.NewGuid().ToString();


            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ADMIN_ROLE_ID,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = MANAGER_ROLE_ID,
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                },
                new IdentityRole
                {
                    Id = CONSULTANT_ROLE_ID,
                    Name = "Consultant",
                    NormalizedName = "CONSULTANT"
                },
                new IdentityRole
                {
                    Id = CUSTOMER_ROLE_ID,
                    Name = "Customer",
                    NormalizedName = "CUSTOMER"
                });

            string ADMIN_ID = Guid.NewGuid().ToString();
            string MANAGER_ID = Guid.NewGuid().ToString();
            string CUSTOMER_ID = Guid.NewGuid().ToString();
            string CONSULTANT_ID = Guid.NewGuid().ToString();


            var admin = new User
            {
                Id = ADMIN_ID,
                UserName = "admin@keysshop.com",
                Email = "admin@keysshop.com",
                EmailConfirmed = true,
                NormalizedEmail = "admin@keysshop.com".ToUpper(),
                NormalizedUserName = "admin@keysshop.com".ToUpper()
            };
            var manager = new User
            {
                Id = MANAGER_ID,
                UserName = "manager@keysshop.com",
                Email = "manager@keysshop.com",
                EmailConfirmed = true,
                NormalizedEmail = "manager@keysshop.com".ToUpper(),
                NormalizedUserName = "manager@keysshop.com".ToUpper()
            };
            var customer = new User
            {
                Id = CUSTOMER_ID,
                UserName = "customer@keysshop.com",
                Email = "customer@keysshop.com",
                EmailConfirmed = true,
                NormalizedEmail = "customer@keysshop.com".ToUpper(),
                NormalizedUserName = "customer@keysshop.com".ToUpper()
            };
            var consultant = new User
            {
                Id = CONSULTANT_ID,
                UserName = "consultant@keysshop.com",
                Email = "consultant@keysshop.com",
                EmailConfirmed = true,
                NormalizedEmail = "consultant@keysshop.com".ToUpper(),
                NormalizedUserName = "consultant@keysshop.com".ToUpper()
            };

            PasswordHasher<User> hasher = new PasswordHasher<User>();
            admin.PasswordHash = hasher.HashPassword(admin, "admin$Pass1");
            manager.PasswordHash = hasher.HashPassword(manager, "manager$Pass1");
            customer.PasswordHash = hasher.HashPassword(customer, "customer$Pass1");
            consultant.PasswordHash = hasher.HashPassword(consultant, "consultant$Pass1");

            builder.Entity<User>().HasData(manager, customer, admin, consultant);

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = ADMIN_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MANAGER_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = CUSTOMER_ROLE_ID,
                    UserId = ADMIN_ID
                }, 
                new IdentityUserRole<string>
                {
                    RoleId = CONSULTANT_ROLE_ID,
                    UserId = ADMIN_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = MANAGER_ROLE_ID,
                    UserId = MANAGER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = CUSTOMER_ROLE_ID,
                    UserId = MANAGER_ID
                },
                new IdentityUserRole<string>
                {
                    RoleId = CUSTOMER_ROLE_ID,
                    UserId = CUSTOMER_ID
                },
                new IdentityUserRole<string>
                {
                     RoleId = CUSTOMER_ROLE_ID,
                     UserId = CONSULTANT_ID
                },
                new IdentityUserRole<string>
                 {
                      RoleId = CONSULTANT_ROLE_ID,
                      UserId = CONSULTANT_ID
                 });
        }
    }
}