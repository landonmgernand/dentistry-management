using DentistryManagement.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DentistryManagement.Server.Data.DatabaseSeeders
{
    public class UserSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var adminId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";

            ApplicationUser applicationUser = new ApplicationUser
            {
                Id = adminId,
                UserName = "admin@graphene.com",
                NormalizedUserName = "admin@graphene.com",
                FirstName = "Graphene",
                LastName = "Graphene",
                Email = "admin@graphene.com",
                NormalizedEmail = "admin@graphene.com",
                EmailConfirmed = true
            };

            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = passwordHasher.HashPassword(applicationUser, "Gr@phene666");

            applicationUser.PasswordHash = passwordHash;
            builder.Entity<ApplicationUser>().HasData(applicationUser);
        }
    }
}
