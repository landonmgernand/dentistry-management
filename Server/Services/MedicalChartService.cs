using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Models;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
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
            var patient = _context.Patients.Find(patientId);
            TeethSettingsDTO teeth = _settings.Value;
            var medicalChart = new MedicalChart
            {
                Patient = patient
            };
            medicalChart.Teeth = new List<Tooth>();

            foreach (ToothSettingsDTO toothSettings in teeth.Teeth)
            {
                Tooth tooth = new Tooth() { Url = toothSettings.Url, Category = toothSettings.Category, Order = toothSettings.Order };
                medicalChart.Teeth.Add(tooth);
            }

            _context.MedicalCharts.Add(medicalChart);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.MedicalCharts.Any(x => x.Id.Equals(id));
        }

        public MedicalChartDTO Get(int id)
        {
            var medicalChart = _context.MedicalCharts.SingleOrDefault(mc => mc.Id.Equals(id));

            if (medicalChart is null)
            {
                return null;
            }

            return MedicalChartMapper.MedicalChartToDTO(medicalChart);
        }

        public TeethCategoryDTO GetTeeth(int medicalChartId)
        {
            var teethDTO = _context.Teeth
                .Where(t => t.MedicalChartId.Equals(medicalChartId))
                .Include(t => t.ToothDiseases)
                .OrderBy(t => t.Order)
                .Select(t => ToothMapper.ToothToDTO(t))
                .ToList();

            return ToothMapper.TeethToTeethCategoryDTO(teethDTO);
        }

        public List<AllergyDTO> GetAllergies(int medicalChartId)
        {
            var allergiesDTO = _context.Allergies
                .Where(a => a.MedicalChartId.Equals(medicalChartId))
                .Select(a => AllergyMapper.AllergyToDTO(a))
                .ToList();

            return allergiesDTO;
        }
    }
}
