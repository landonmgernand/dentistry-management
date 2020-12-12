using DentistryManagement.Server.DataTransferObjects;
using System;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface IStatisticService
    {
        public StatisticDTO Get();

        public StatisticDTO Get(int affiliateId);

        public StatisticDTO GetStatisticData(
            int affiliateId,
            DateTime firstDay,
            DateTime firstDayLastMonth,
            DateTime lastDay,
            DateTime lastDayLastMonth);
    }
}
