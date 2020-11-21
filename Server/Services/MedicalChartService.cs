using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Models;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class MedicalChartService : IMedicalChartService
    {
        private readonly ApplicationDbContext _context;
        private readonly IOptions<TeethSettingsDTO> _settings;

        public MedicalChartService(ApplicationDbContext context, IOptions<TeethSettingsDTO> settings)
        {
            _context = context;
            _settings = settings;
        }

        public void Create(int patientId)
        {
            var patient = _context.Patient.Find(patientId);
            TeethSettingsDTO teeth = _settings.Value;
            var medicalChart = new MedicalChart
            {
                Patient = patient
            };
            medicalChart.Teeth = new List<Teeth>();

            foreach (ToothSettingsDTO toothSettings in teeth.Teeth)
            {
                Teeth tooth = new Teeth() { Url = toothSettings.Url, Category = toothSettings.Category, Order = toothSettings.Order };
                medicalChart.Teeth.Add(tooth);
            }

            _context.MedicalChart.Add(medicalChart);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.MedicalChart.Any(x => x.Id.Equals(id));
        }

        public MedicalChartDTO Get(int id)
        {
            var medicalChart = _context.MedicalChart.SingleOrDefault(mc => mc.Id.Equals(id));

            if (medicalChart is null)
            {
                return null;
            }

            return MedicalChartMapper.MedicalChartToDTO(medicalChart);
        }

        public TeethCategoryDTO GetTeeth(int id)
        {
            var teethDTO = _context.Teeth
                .Where(t => t.MedicalChartId.Equals(id))
                .OrderBy(t => t.Order)
                .Select(t => TeethMapper.TeethToDTO(t))
                .ToList();

            return TeethMapper.TeethToTeethCategoryDTO(teethDTO);
        }
    }
}
