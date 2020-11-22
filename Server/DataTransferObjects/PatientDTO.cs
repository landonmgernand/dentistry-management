using System;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class PatientDTO
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public MedicalChartDTO MedicalChartDTO { get; set; }
    }
}
