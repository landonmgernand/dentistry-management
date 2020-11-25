using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class AddressService : IAddressService
    {
        private readonly ApplicationDbContext _context;

        public AddressService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(AddressDTO addressDTO)
        {
            var address = AddressMapper.DTOtoAddress(addressDTO);
            var affiliate = _context.Affiliates.Find(addressDTO.AffiliateId);
            affiliate.Address = address;

            _context.SaveChanges();
        }

        public bool Exist(int id, int affiliateId)
        {
            return _context.Addresses.Any(a => a.Id.Equals(id) && a.AffiliateId.Equals(affiliateId));
        }

        public AddressDTO Get(int affiliateId)
        {
            var affiliateAddress = _context.Addresses
                .SingleOrDefault(a => a.AffiliateId.Equals(affiliateId));

            if (affiliateAddress is null)
            {
                return null;
            }

            return AddressMapper.AddressToDTO(affiliateAddress);
        }

        public void Update(AddressDTO addressDTO)
        {
            var address = _context.Addresses.SingleOrDefault(a => a.Id.Equals(addressDTO.Id));
            address.Address1 = addressDTO.Address1;
            address.Address2 = addressDTO.Address2;
            address.PostalCode = addressDTO.PostalCode;
            address.City = addressDTO.City;
            address.Country = addressDTO.Country;
            _context.SaveChanges();
        }
    }
}
