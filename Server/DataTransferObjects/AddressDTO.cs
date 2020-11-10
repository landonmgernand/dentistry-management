using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class AddressDTO
    {
        public int Id { get; set; }

        public int AffiliateId { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }

        public string Country { get; set; }
    }
}
