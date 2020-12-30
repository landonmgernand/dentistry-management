using DentistryManagement.Server.DataTransferObjects;
using System.Collections.Generic;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IScheduleService<T> : IService<T>
    {
        public List<ScheduleDTO> GetAffiliateSchedule(int affiliateId);
    }
}
