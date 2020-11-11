using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Addresses;

namespace DentistryManagement.Server.Mappers
{
    public class AddressMapper
    {
        public static AddressDTO CreateAddressVMToDTO(CreateAddressViewModel createAddressViewModel)
        {
            return new AddressDTO
            {
                AffiliateId = createAddressViewModel.AffiliateId,
                Address1 = createAddressViewModel.Address1,
                Address2 = createAddressViewModel.Address2,
                PostalCode = createAddressViewModel.PostalCode,
                City = createAddressViewModel.City,
                Country = createAddressViewModel.Country,
            };
        }

        public static AddressDTO UpdateAddressVMToDTO(UpdateAddressViewModel updateAddressViewModel)
        {
            return new AddressDTO
            {
                Id = updateAddressViewModel.Id,
                AffiliateId = updateAddressViewModel.AffiliateId,
                Address1 = updateAddressViewModel.Address1,
                Address2 = updateAddressViewModel.Address2,
                PostalCode = updateAddressViewModel.PostalCode,
                City = updateAddressViewModel.City,
                Country = updateAddressViewModel.Country,            
            };
        }

        public static AddressDTO AddressToDTO(Address address)
        {
            return new AddressDTO
            {
                Id = address.Id,
                AffiliateId = address.AffiliateId,
                Address1 = address.Address1,
                Address2 = address.Address2,
                PostalCode = address.PostalCode,
                City = address.City,
                Country = address.Country
            };
        }

        public static Address DTOtoAddress(AddressDTO addressDTO)
        {
            return new Address
            {
                Address1 = addressDTO.Address1,
                Address2 = addressDTO.Address2,
                PostalCode = addressDTO.PostalCode,
                City = addressDTO.City,
                Country = addressDTO.Country
            };
        }

        public static AddressViewModel DTOtoAddressVM(AddressDTO addressDTO)
        {
            return new AddressViewModel
            {
                Id = addressDTO.Id,
                AffiliateId = addressDTO.AffiliateId,
                Address1 = addressDTO.Address1,
                Address2 = addressDTO.Address2,
                PostalCode = addressDTO.PostalCode,
                City = addressDTO.City,
                Country = addressDTO.Country
            };
        }

        public static string DTOtoAddressString(AddressDTO addressDTO)
        {
            return addressDTO.Address1 + " " + 
                addressDTO.Address2 + " " + 
                addressDTO.PostalCode + " " + 
                addressDTO.City + " " + 
                addressDTO.Country;
        }
    }
}
