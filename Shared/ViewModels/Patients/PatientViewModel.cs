using DentistryManagement.Shared.ViewModels.MedicalChart;
using System;

namespace DentistryManagement.Shared.ViewModels.Patients
{
    public class PatientViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public bool MedicalChartOpen { get; set; }

        public MedicalChartViewModel  MedicalChart { get; set; }
    }
}
