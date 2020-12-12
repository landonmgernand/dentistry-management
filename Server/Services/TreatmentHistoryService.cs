using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Helpers;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class TreatmentHistoryService : ITreatmentHistoryService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProviderService _userProviderService;

        public TreatmentHistoryService(ApplicationDbContext context, IUserProviderService userProviderService)
        {
            _context = context;
            _userProviderService = userProviderService;
        }

        public void Create(TreatmentHistoryDTO treatmentHistoryDTO)
        {
            var treatmentHistory = TreatmentHistoryMapper.DTOtoTreatmentHistory(treatmentHistoryDTO);
            var medicalChart = _context.MedicalCharts.Find(treatmentHistoryDTO.MedicalChartId);
            var treatment = _context.Treatments.Find(treatmentHistoryDTO.TreatmentId);
            var tooth = _context.Teeth.Find(treatmentHistoryDTO.ToothId);

            string userId;

            if (treatmentHistoryDTO.UserId is null)
            {
                 userId = _userProviderService.GetUserId();
            } else
            {
                 userId = treatmentHistoryDTO.UserId;
            }

            var user = _context.ApplicationUsers.Find(userId);

            var affiliateId = _context.ApplicationUsers
               .Where(u => u.Id.Equals(userId))
               .Select(u => u.AffiliateId)
               .Single();

            var affiliate = _context.Affiliates.Find(affiliateId);

            treatmentHistory.Price = treatment.Price;
            treatmentHistory.Treatment = treatment;
            treatmentHistory.Tooth = tooth;
            treatmentHistory.Affiliate = affiliate;
            treatmentHistory.MedicalChart = medicalChart;
            treatmentHistory.User = user;

            _context.TreatmentHistories.Add(treatmentHistory);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var treatmentHistory = _context.TreatmentHistories.Find(id);
            _context.TreatmentHistories.Remove(treatmentHistory);
            _context.SaveChanges();
        }

        public bool Exist(int medicalChartId, int treatmentHistoryId)
        {
            return _context.TreatmentHistories.Any(th => th.Id.Equals(treatmentHistoryId) && th.MedicalChartId.Equals(medicalChartId));
        }

        public TreatmentHistoryDTO Get(int medicalChartId, int treatmentHistoryId)
        {
            var treatmentHistory = _context.TreatmentHistories
                 .Include(th => th.User)
                 .Include(th => th.Treatment)
                 .Include(th => th.Tooth)
                 .Include(th => th.Affiliate)
                 .Where(th => th.Id.Equals(treatmentHistoryId))
                 .Where(th => th.MedicalChartId.Equals(medicalChartId))
                 .SingleOrDefault();

            if (treatmentHistory == null)
            {
                return null;
            }

            return TreatmentHistoryMapper.TreatmentHistoryToDTO(treatmentHistory);
        }

        public void Update(TreatmentHistoryDTO treatmentHistoryDTO)
        {
            var treatmentHistory = _context.TreatmentHistories.Find(treatmentHistoryDTO.Id);
            var treatment = _context.Treatments.Find(treatmentHistoryDTO.TreatmentId);
            var tooth = _context.Teeth.Find(treatmentHistoryDTO.ToothId);
            string userId;

            if (treatmentHistoryDTO.UserId is null)
            {
                userId = _userProviderService.GetUserId();
            }
            else
            {
                userId = treatmentHistoryDTO.UserId;
            }

            var user = _context.ApplicationUsers.Find(userId);

            var affiliateId = _context.ApplicationUsers
           .Where(u => u.Id.Equals(userId))
           .Select(u => u.AffiliateId)
           .Single();

            var affiliate = _context.Affiliates.Find(affiliateId);

            treatmentHistory.Comment = treatmentHistoryDTO.Comment;
            treatmentHistory.Treatment = treatment;
            treatmentHistory.Tooth = tooth;
            treatmentHistory.Price = treatment.Price;
            treatmentHistory.Affiliate = affiliate;
            treatmentHistory.User = user;

            _context.SaveChanges();
        }
    }
}
