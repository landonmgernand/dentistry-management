using System;

namespace DentistryManagement.Shared.ViewModels.TreatmentHistories
{
    public class TreatmentHistoryViewModel
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public decimal Price { get; set; }

        public string DateOfTreatment { get; set; }

        public string User { get; set; }

        public string UserId { get; set; }

        public string Treatment { get; set; }

        public int TreatmentId { get; set; }

        public string Affiliate { get; set; }
    }
}
