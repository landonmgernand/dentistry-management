using DentistryManagement.Shared.ViewModels.Addresses;

namespace DentistryManagement.Shared.ViewModels.Affiliates
{
    public class AffiliateViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public AddressViewModel Address { get; set; }
    }
}
