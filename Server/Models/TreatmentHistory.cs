using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DentistryManagement.Server.Models
{
    public class TreatmentHistory
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Price { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfTreatment { get; set; }

        public int MedicalChartId { get; set; }

        public MedicalChart MedicalChart { get; set; }

        public int TreatmentId { get; set; }

        public Treatment Treatment { get; set; }

        public int ToothId { get; set; }

        public Tooth Tooth { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int AffiliateId { get; set; }

        public Affiliate Affiliate { get; set; }
    }
}
