using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Helpers;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class ScheduleService : IScheduleService<ScheduleDTO>
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProviderService _userProviderService;

        public ScheduleService(ApplicationDbContext context, IUserProviderService userProviderService)
        {
            _context = context;
            _userProviderService = userProviderService;
        }

        public void Create(ScheduleDTO scheduleDTO)
        {
            var schedule = ScheduleMapper.DTOtoSchedule(scheduleDTO);
            var patient = _context.Patients.Find(scheduleDTO.PatientId);
            var user = _context.ApplicationUsers.Find(_userProviderService.GetUserId());

            schedule.Patient = patient;
            schedule.User = user;

            _context.Schedule.Add(schedule);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var schedule = _context.Schedule.Find(id);
            _context.Schedule.Remove(schedule);
            _context.SaveChanges();
        }

        public bool Exist(int id)
        {
            return _context.Schedule.Any(th => th.Id.Equals(id));
        }

        public ScheduleDTO Get(int id)
        {
            var schedule = _context.Schedule
                .Include(s => s.Patient)
                .Where(s => s.Id.Equals(id))
                .Where(s => s.UserId.Equals(_userProviderService.GetUserId()))
                .SingleOrDefault();

            if (schedule is null)
            {
                return null;
            }

            return ScheduleMapper.ScheduleToDTO(schedule);
        }

        public List<ScheduleDTO> GetAll()
        {
            var scheduleDTOs = _context.Schedule
                .Include(s => s.Patient)
                .Where(s => s.UserId.Equals(_userProviderService.GetUserId()))
                .Select(s => ScheduleMapper.ScheduleToDTO(s))
                .ToList();

            return scheduleDTOs;
        }

        public void Update(ScheduleDTO scheduleDTO)
        {
            var schedule = _context.Schedule.Find(scheduleDTO.Id);
            schedule.StartTime = scheduleDTO.StartTime;
            schedule.EndTime = scheduleDTO.EndTime;
            _context.SaveChanges();
        }
    }
}
