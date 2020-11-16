using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Patients;

namespace DentistryManagement.Server.Mappers
{
    public class PatientMapper
    {
        public static PatientDTO CreatePatientVMToDTO(CreatePatientViewModel createPatientViewModel)
        {
            return new PatientDTO
            {
                FirstName = createPatientViewModel.FirstName,
                LastName = createPatientViewModel.LastName,
                DateOfBirth = createPatientViewModel.DateOfBirth,
                Email = createPatientViewModel.Email,
                PhoneNumber = createPatientViewModel.PhoneNumber,
            };
        }

        public static PatientDTO UpdatePatientVMToDTO(UpdatePatientViewModel updatePatientViewModel)
        {
            return new PatientDTO
            {
                Id = updatePatientViewModel.Id,
                FirstName = updatePatientViewModel.FirstName,
                LastName = updatePatientViewModel.LastName,
                DateOfBirth = updatePatientViewModel.DateOfBirth,
                Email = updatePatientViewModel.Email,
                PhoneNumber = updatePatientViewModel.PhoneNumber,
            };
        }

        public static PatientDTO PatientToDTO(Patient patient)
        {
            return new PatientDTO
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Email = patient.Email,
                PhoneNumber = patient.PhoneNumber,
            };
        }

        public static Patient DTOtoPatient(PatientDTO patientDTO)
        {
            return new Patient
            {
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                DateOfBirth = patientDTO.DateOfBirth,
                Email = patientDTO.Email,
                PhoneNumber = patientDTO.PhoneNumber,
            };
        }

        public static PatientViewModel DTOtoPatientVM(PatientDTO patientDTO)
        {
            return new PatientViewModel
            {
                Id = patientDTO.Id,
                FirstName = patientDTO.FirstName,
                LastName = patientDTO.LastName,
                DateOfBirth = patientDTO.DateOfBirth,
                Email = patientDTO.Email,
                PhoneNumber = patientDTO.PhoneNumber,
            };
        }
    }
}
