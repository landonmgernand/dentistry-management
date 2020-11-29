using DentistryManagement.Server.Models;
using System;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class TreatmentHistoryDTO
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfTreatment { get; set; }

        public int MedicalChartId { get; set; }

        public MedicalChart MedicalChart { get; set; }

        public int TreatmentId { get; set; }

        public Treatment Treatment { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int AffiliateId { get; set; }

        public Affiliate Affiliate { get; set; }
    }
}
