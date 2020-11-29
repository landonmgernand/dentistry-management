using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Server.Models
{
    public class Disease
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<ToothDisease> ToothDiseases { get; set; }
    }
}
