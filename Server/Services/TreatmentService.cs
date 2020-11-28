using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class TreatmentService : ITreatmentService<TreatmentDTO>
    {
        private readonly ApplicationDbContext _context;

        public TreatmentService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(TreatmentDTO item)
        {
            var treatment = TreatmentMapper.DTOtoTreatment(item);
            _context.Treatments.Add(treatment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var treatment = _context.Treatments.Find(id);
            _context.Treatments.Remove(treatment);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Treatments.Any(x => x.Id.Equals(id));
        }

        public TreatmentDTO Get(int id)
        {
            var treatment = _context.Treatments.SingleOrDefault(d => d.Id.Equals(id));

            if (treatment is null)
            {
                return null;
            }

            return TreatmentMapper.TreatmentToDTO(treatment);
        }

        public List<TreatmentDTO> GetAll()
        {
            var treatmentDTOs = _context.Treatments
              .Select(t => TreatmentMapper.TreatmentToDTO(t))
              .ToList();

            return treatmentDTOs;
        }

        public void Update(TreatmentDTO item)
        {
            var treatment = _context.Treatments.SingleOrDefault(t => t.Id.Equals(item.Id));
            treatment.Name = item.Name;
            treatment.Price = item.Price;
            _context.SaveChanges();
        }
    }
}
