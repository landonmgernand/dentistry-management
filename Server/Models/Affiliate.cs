using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Server.Models
{
    public class Affiliate
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public Address Address { get; set; }

        public ICollection<ApplicationUser> Users { get; set; }
    }
}
