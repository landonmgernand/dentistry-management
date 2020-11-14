using DentistryManagement.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace DentistryManagement.Server.Data.DatabaseSeeders
{
    public class AffiliateSeeder
    {
        public static void Seed(ModelBuilder builder)
        {
            var Id = 1;

            builder.Entity<Affiliate>().HasData(
                new Affiliate
                {
                    Id = Id,
                    Name = "Graphene"
                });
        }
    }
}
