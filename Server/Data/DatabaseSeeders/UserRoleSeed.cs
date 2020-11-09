using DentistryManagement.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Data.DatabaseSeeders
{
    public class UserRoleSeed
    {
        public static void Seed(ModelBuilder builder)
        {
            var adminUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
            var adminRoleId = "2301D884-221A-4E7D-B509-0113DCC043E1";

            builder.Entity<ApplicationUserRole>().HasData(
                new ApplicationUserRole
                {
                    RoleId = adminRoleId,
                    UserId = adminUserId
                });
        }
    }
}
