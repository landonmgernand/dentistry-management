using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Schedule;

namespace DentistryManagement.Server.Mappers
{
    public class ScheduleMapper
    {
        public static ScheduleDTO CreateScheduleVMtoDTO(CreateScheduleViewModel createSchedule)
        {
            return new ScheduleDTO
            {
                PatientId = createSchedule.PatientId,
                UserId = createSchedule.UserId,
                StartTime = createSchedule.StartTime,
                EndTime = createSchedule.EndTime
            };
        }

        public static ScheduleDTO UpdateScheduleVMToDTO(UpdateScheduleViewModel updateSchedule)
        {
            return new ScheduleDTO
            {
                Id = updateSchedule.Id,
                UserId = updateSchedule.UserId,
                StartTime = updateSchedule.StartTime,
                EndTime = updateSchedule.EndTime
            };
        }

        public static ScheduleDTO ScheduleToDTO(Schedule schedule)
        {
            return new ScheduleDTO
            {
                Id = schedule.Id,
                StartTime = schedule.StartTime,
                EndTime = schedule.EndTime,
                PatientDTO = schedule.Patient is null ? null : PatientMapper.PatientToDTO(schedule.Patient),
                UserId = schedule.UserId
            };
        }

        public static Schedule DTOtoSchedule(ScheduleDTO scheduleDTO)
        {
            return new Schedule
            {
                StartTime = scheduleDTO.StartTime,
                EndTime = scheduleDTO.EndTime,
            };
        }

        public static ScheduleViewModel DTOtoScheduleVM(ScheduleDTO scheduleDTO)
        {
            return new ScheduleViewModel
            {
                Id = scheduleDTO.Id,
                Subject = scheduleDTO.PatientDTO is null ? null : PatientMapper.DTOtoPatientString(scheduleDTO.PatientDTO),
                UserId = scheduleDTO.UserId,
                StartTime = scheduleDTO.StartTime,
                EndTime = scheduleDTO.EndTime
            };
        }
    }
}
