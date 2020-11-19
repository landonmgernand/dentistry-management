using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Server.Models
{
    public class Teeth
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Url { get; set; }

        public int MedicalChartId { get; set; }

        public MedicalChart MedicalChart { get; set; }

        public int ToothCategoryId { get; set; }

        public ToothCategory ToothCategory { get; set; }
    }
}
