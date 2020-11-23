using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Models;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class ToothService : IToothService
    {
        private readonly ApplicationDbContext _context;

        public ToothService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateToothDiseases(ToothDiseasesDTO toothDiseasesDTO)
        {
            var tooth = _context.Teeth.Include(td => td.ToothDiseases).SingleOrDefault(t => t.Id.Equals(toothDiseasesDTO.ToothId));

            tooth.ToothDiseases.Clear();

            foreach (var toothDiseaseDTO in toothDiseasesDTO.Diseases)
            {
                tooth.ToothDiseases.Add(new ToothDisease()
                {
                    DiseaseId = toothDiseaseDTO.Id,
                    ToothId = tooth.Id
                });
            }

            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Teeth.Any(x => x.Id.Equals(id));
        }

        public List<DiseaseDTO> GetDiseases(int id)
        {
            var diseases = _context.Diseases
                .Include(td => td.ToothDiseases)
                .Where(td => td.ToothDiseases.Any(td => td.ToothId.Equals(id)))
                .Select(d => DiseaseMapper.DiseaseToDTO(d))
                .ToList();

            return diseases;
        }
    }
}
