namespace DentistryManagement.Server.DataTransferObjects
{
    public class DentistDTO
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string NewPassword { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public int AffiliateId { get; set; }

        public AffiliateDTO AffiliateDTO { get; set; }
    }
}
