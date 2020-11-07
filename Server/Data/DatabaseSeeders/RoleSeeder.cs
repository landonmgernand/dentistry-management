using DentistryManagement.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DentistryManagement.Server.Data.DatabaseSeeders
{
    public class RoleSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var adminId = "2301D884-221A-4E7D-B509-0113DCC043E1";

            builder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                { 
                    Id = adminId,
                    Name = "Admin",
                    NormalizedName = "Admin"
                }, 
                new ApplicationRole
                {
                    Name = "User",
                    NormalizedName = "User"
                });
        }
    }
}
