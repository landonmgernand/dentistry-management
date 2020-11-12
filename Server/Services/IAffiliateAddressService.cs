using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.Services
{
    public interface IAffiliateAddressService<T>
    {
        public T GetAffiliateAddress(int affiliateId);
        public void CreateAffiliateAddress(T item);
        public void UpdateAffiliateAddress(T item);
        public bool AffiliateAddressExist(int id, int affiliateId);
    }
}
