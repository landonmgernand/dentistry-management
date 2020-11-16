using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class AffiliateService : IAffiliateService<AffiliateDTO, AddressDTO>
    {
        private readonly ApplicationDbContext _context;

        public AffiliateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool AffiliateAddressExist(int id, int affiliateId)
        {
            return _context.Address.Any(a => a.Id.Equals(id) && a.AffiliateId.Equals(affiliateId));
        }

        public void Create(AffiliateDTO item)
        {
            var affiliate = AffiliateMapper.DTOtoAffiliate(item);
            _context.Affiliate.Add(affiliate);
            _context.SaveChanges();
        }

        public void CreateAffiliateAddress(AddressDTO item)
        {
            var address = AddressMapper.DTOtoAddress(item);
            var affiliate = _context.Affiliate.Find(item.AffiliateId);
            affiliate.Address = address;

            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var affiliate = _context.Affiliate.Find(id);
            _context.Affiliate.Remove(affiliate);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Affiliate.Any(x => x.Id.Equals(id));
        }

        public AffiliateDTO Get(int id)
        {
            var affiliate = _context.Affiliate.Include(a => a.Address).SingleOrDefault(a => a.Id.Equals(id));

            return AffiliateMapper.AffiliateToDTO(affiliate);
        }

        public AddressDTO GetAffiliateAddress(int affiliateId)
        {
            var affiliateAddress = _context.Address
                .SingleOrDefault(a => a.AffiliateId.Equals(affiliateId));

            if (affiliateAddress is null)
            {
                return null;
            }

            return AddressMapper.AddressToDTO(affiliateAddress);
        }

        public List<AffiliateDTO> GetAll()
        {
            var affiliates = _context.Affiliate
                .Include(a => a.Address)
                .Select(a => AffiliateMapper.AffiliateToDTO(a))
                .ToList();

            return affiliates;
        }

        public void Update(AffiliateDTO item)
        {
            var affiliate = _context.Affiliate.SingleOrDefault(a => a.Id.Equals(item.Id));
            affiliate.Name = item.Name;
            _context.SaveChanges();
        }

        public void UpdateAffiliateAddress(AddressDTO item)
        {
            var address = _context.Address.SingleOrDefault(a => a.Id.Equals(item.Id));
            address.Address1 = item.Address1;
            address.Address2 = item.Address2;
            address.PostalCode = item.PostalCode;
            address.City = item.City;
            address.Country = item.Country;
            _context.SaveChanges();
        }
    }
}
