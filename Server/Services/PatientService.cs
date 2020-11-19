using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class PatientService : IPatientService<PatientDTO>
    {
        private readonly ApplicationDbContext _context;

        public PatientService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(PatientDTO item)
        {
            var patient = PatientMapper.DTOtoPatient(item);
            _context.Patient.Add(patient);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var patient = _context.Patient.Find(id);
            _context.Patient.Remove(patient);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Patient.Any(x => x.Id.Equals(id));
        }

        public PatientDTO Get(int id)
        {
            var patient = _context.Patient.Include(p => p.MedicalChart).SingleOrDefault(p => p.Id.Equals(id));

            if (patient is null)
            {
                return null;
            }

            return PatientMapper.PatientToDTO(patient);
        }

        public List<PatientDTO> GetAll()
        {
            var patients = _context.Patient
                .Select(p => PatientMapper.PatientToDTO(p))
                .ToList();

            return patients;
        }

        public void Update(PatientDTO item)
        {
            var patient = _context.Patient.SingleOrDefault(a => a.Id.Equals(item.Id));
            patient.FirstName = item.FirstName;
            patient.LastName = item.LastName;
            patient.DateOfBirth = item.DateOfBirth;
            patient.Email = item.Email;
            patient.PhoneNumber = item.PhoneNumber;
            _context.SaveChanges();
        }
    }
}
