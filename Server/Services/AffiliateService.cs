using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class AffiliateService : IAffiliateService<AffiliateDTO>
    {
        private readonly ApplicationDbContext _context;

        public AffiliateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(AffiliateDTO item)
        {
            var affiliate = AffiliateMapper.DTOtoAffiliate(item);
            _context.Affiliates.Add(affiliate);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var affiliate = _context.Affiliates.Find(id);
            _context.Affiliates.Remove(affiliate);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Affiliates.Any(x => x.Id.Equals(id));
        }

        public AffiliateDTO Get(int id)
        {
            var affiliate = _context.Affiliates.Include(a => a.Address).SingleOrDefault(a => a.Id.Equals(id));

            if (affiliate is null)
            {
                return null;
            }

            return AffiliateMapper.AffiliateToDTO(affiliate);
        }

        public List<AffiliateDTO> GetAll()
        {
            var affiliates = _context.Affiliates
                .Include(a => a.Address)
                .Select(a => AffiliateMapper.AffiliateToDTO(a))
                .ToList();

            return affiliates;
        }

        public void Update(AffiliateDTO item)
        {
            var affiliate = _context.Affiliates.SingleOrDefault(a => a.Id.Equals(item.Id));
            affiliate.Name = item.Name;
            _context.SaveChanges();
        }
    }
}
