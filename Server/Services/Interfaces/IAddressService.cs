using DentistryManagement.Server.DataTransferObjects;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IAddressService
    {
        public AddressDTO Get(int affiliateId);
        public void Create(AddressDTO addressDTO);
        public void Update(AddressDTO addressDTO);
        public bool Exist(int id, int affiliateId);
    }
}
