using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class DiseaseService : IDiseaseService<DiseaseDTO>
    {
        private readonly ApplicationDbContext _context;

        public DiseaseService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(DiseaseDTO item)
        {
            var disease = DiseaseMapper.DTOtoDisease(item);
            _context.Diseases.Add(disease);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var disease = _context.Diseases.Find(id);
            _context.Diseases.Remove(disease);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Diseases.Any(x => x.Id.Equals(id));
        }

        public DiseaseDTO Get(int id)
        {
            var disease = _context.Diseases.SingleOrDefault(d => d.Id.Equals(id));

            if (disease is null)
            {
                return null;
            }

            return DiseaseMapper.DiseaseToDTO(disease);
        }

        public List<DiseaseDTO> GetAll()
        {
            var diseases = _context.Diseases
                .Select(d => DiseaseMapper.DiseaseToDTO(d))
                .ToList();

            return diseases;
        }

        public void Update(DiseaseDTO item)
        {
            var disease = _context.Diseases.SingleOrDefault(d => d.Id.Equals(item.Id));
            disease.Name = item.Name;
            disease.Description = item.Description;
            _context.SaveChanges();
        }
    }
}
