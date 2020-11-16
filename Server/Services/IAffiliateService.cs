namespace DentistryManagement.Server.Services
{
    public interface IAffiliateService<T, R> : IService<T>
    {
        public R GetAffiliateAddress(int affiliateId);
        public void CreateAffiliateAddress(R item);
        public void UpdateAffiliateAddress(R item);
        public bool AffiliateAddressExist(int id, int affiliateId);
    }
}
