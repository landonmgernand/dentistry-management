using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Services
{
    public class AllergyService : IAllergyService
    {
        private readonly ApplicationDbContext _context;

        public AllergyService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(AllergyDTO allergyDTO)
        {
            var medicalChart = _context.MedicalCharts.SingleOrDefault(mc => mc.Id.Equals(allergyDTO.MedicalChartId));
            var allergy = AllergyMapper.DTOtoAllergy(allergyDTO);
            allergy.MedicalChart = medicalChart;
            _context.Allergies.Add(allergy);
            _context.SaveChanges();
        }

        public void Delete(int allergyId)
        {
            var allergy = _context.Allergies.Find(allergyId);
            _context.Allergies.Remove(allergy);
            _context.SaveChanges();
        }

        public bool Exist(int allergyId)
        {
            return _context.Allergies.Any(x => x.Id.Equals(allergyId));
        }
    }
}
