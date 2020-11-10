using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Server.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Address1 { get; set; }

        [MaxLength(100)]
        public string Address2 { get; set; }

        [Required]
        [MaxLength(20)]
        public string PostalCode { get; set; }

        [Required]
        [MaxLength(50)]
        public string City { get; set; }

        [Required]
        [MaxLength(50)]
        public string Country { get; set; }

        public int AffiliateId { get; set; }

        public Affiliate Affiliate { get; set; }
    }
}
