using DentistryManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DentistryManagement.Server.Data.DatabaseSeeders
{
    public class ToothCategorySeed
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<ToothCategory>().HasData(
                new ToothCategory
                {
                    Id = 1,
                    Name = "UpperRight",
                },
                new ToothCategory
                {
                    Id = 2,
                    Name = "UpperLeft",
                },
                new ToothCategory
                {
                    Id = 3,
                    Name = "LowerRight",
                },
                new ToothCategory
                {
                    Id = 4,
                    Name = "LowerLeft",
                });
        }
    }
}
