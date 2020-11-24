using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Server.Models
{
    public class Allergy
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int MedicalChartId { get; set; }

        public MedicalChart MedicalChart { get; set; }
    }
}
