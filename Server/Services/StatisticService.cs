using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Helpers;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class StatisticService : IStatisticService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProviderService _userProviderService;

        public StatisticService(ApplicationDbContext context, IUserProviderService userProviderService)
        {
            _context = context;
            _userProviderService = userProviderService;
        }

        public StatisticDTO Get()
        {
            var affiliateId = _context.ApplicationUsers
                .Where(u => u.Id.Equals(_userProviderService.GetUserId()))
                .Select(u => u.AffiliateId)
                .Single();

            var patientCount = _context.Patients
                .Count();
            var treatmentCount = _context.TreatmentHistories
                .Where(th => th.AffiliateId.Equals(affiliateId))
                .Count();

            var firstDay = DateTimeDayOfMonth.FirstDayOfMonth(DateTime.Now);
            var firstDayLastMonth = DateTimeDayOfMonth.FirstDayOfMonth(DateTime.Now.AddMonths(-1));
            var lastDay = DateTimeDayOfMonth.LastDayOfMonth(DateTime.Now);
            var lastDayLastMonth = DateTimeDayOfMonth.LastDayOfMonth(DateTime.Now.AddMonths(-1));

            var lastMonthTreatmentHistories = _context.TreatmentHistories.Where(th => th.DateOfTreatment >= firstDayLastMonth
               && th.DateOfTreatment <= lastDayLastMonth)
                .Where(th => th.AffiliateId.Equals(affiliateId))
                .ToList();

            var thisMonthTreatmentHistories = _context.TreatmentHistories.Where(th => th.DateOfTreatment >= firstDay
               && th.DateOfTreatment <= lastDay)
                .Where(th => th.AffiliateId.Equals(affiliateId))
                .ToList();

            var overallTreatmentHistories = _context.TreatmentHistories
                .Where(th => th.AffiliateId.Equals(affiliateId))
                .Include(th => th.Treatment)
                .ToList();

            var monthlyEarnings = lastMonthTreatmentHistories
                .Sum(th => th.Price);

            var overallEarnings = overallTreatmentHistories
                .Sum(th => th.Price);

            MonthlyTreatmentHistoryDTO monthlyTreatmentHistory = new MonthlyTreatmentHistoryDTO()
            {
                TreatmentHistories = new List<TreatmentHistoryChartDTO>()
            };

            foreach (var treatmentHistory in thisMonthTreatmentHistories)
            {
                var treatmentHistoryChart = monthlyTreatmentHistory.TreatmentHistories
                         .FirstOrDefault(th => th.DateOfTreatment.ToString("dd-MM-yyyy").Equals(treatmentHistory.DateOfTreatment.ToString("dd-MM-yyyy")));
                if (treatmentHistoryChart is null)
                {
                    monthlyTreatmentHistory.TreatmentHistories.Add(new TreatmentHistoryChartDTO()
                    {
                        Count = 1,
                        DateOfTreatment = treatmentHistory.DateOfTreatment
                    });
                }
                else
                {
                    treatmentHistoryChart.Count++;
                }
            }

            monthlyTreatmentHistory.MaxCount = monthlyTreatmentHistory.TreatmentHistories.Count > 0 ?
                monthlyTreatmentHistory.TreatmentHistories.Max(th => th.Count) : 0;

            PopularTreatmentDTO popularTreatment = new PopularTreatmentDTO()
            {
                Treatments = new List<TreatmentChartDTO>()
            };

            foreach (var treatmentHistory in overallTreatmentHistories)
            {
                var treatmentChart = popularTreatment.Treatments
                    .FirstOrDefault(th => th.Name.Equals(treatmentHistory.Treatment.Name));
                if (treatmentChart is null)
                {
                    popularTreatment.Treatments.Add(new TreatmentChartDTO()
                    {
                        Count = 1,
                        Name = treatmentHistory.Treatment.Name
                    });
                }
                else
                {
                    treatmentChart.Count++;
                }
            }

            return StatisticMapper.ToDTO(
                patientCount,
                treatmentCount,
                monthlyEarnings,
                overallEarnings,
                monthlyTreatmentHistory,
                popularTreatment
                );
        }
    }
}
