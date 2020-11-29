using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Affiliates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Mappers
{
    public class AffiliateMapper
    {
        public static AffiliateDTO CreateAffiliateVMToDTO(CreateAffiliateViewModel createAffiliateViewModel)
        {
            return new AffiliateDTO
            {
                Name = createAffiliateViewModel.Name
            };
        }

        public static AffiliateDTO UpdateAffiliateVMToDTO(UpdateAffiliateViewModel updateAffiliateViewModel)
        {
            return new AffiliateDTO
            {
                Id = updateAffiliateViewModel.Id,
                Name = updateAffiliateViewModel.Name
            };
        }

        public static AffiliateDTO AffiliateToDTO(Affiliate affiliate)
        {
            return new AffiliateDTO
            {
                Id = affiliate.Id,
                Name = affiliate.Name,
                AddressDTO = affiliate.Address is null ? null : AddressMapper.AddressToDTO(affiliate.Address)
            };
        }

        public static Affiliate DTOtoAffiliate(AffiliateDTO affiliateDTO)
        {
            return new Affiliate
            {
                Name = affiliateDTO.Name
            };
        }

        public static AffiliateViewModel DTOtoAffiliateVM(AffiliateDTO affiliateDTO)
        {
            return new AffiliateViewModel
            {
                Id = affiliateDTO.Id,
                Name = affiliateDTO.Name,
                Address = affiliateDTO.AddressDTO is null ? null :  AddressMapper.DTOtoAddressString(affiliateDTO.AddressDTO)
            };
        }
    }
}
