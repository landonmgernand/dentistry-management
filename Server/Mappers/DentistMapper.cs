using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Dentists;
using System.Collections.Generic;

namespace DentistryManagement.Server.Mappers
{
    public class DentistMapper
    {
        public static DentistDTO AddDentistViewModelToDTO(CreateDentistViewModel createDentist)
        {
            return new DentistDTO
            {
                Email = createDentist.Email,
                FirstName = createDentist.FirstName,
                LastName = createDentist.LastName,
                Password = createDentist.Password,
                PhoneNumber = createDentist.PhoneNumber
            };
        }

        public static DentistDTO UpdateDentistViewModelToDTO(UpdateDentistViewModel updateDentist)
        {
            return new DentistDTO
            {
                Id = updateDentist.Id,
                FirstName = updateDentist.FirstName,
                LastName = updateDentist.LastName,
                PhoneNumber = updateDentist.PhoneNumber
            };
        }

        public static DentistDTO ApplicationUserToDTO(ApplicationUser applicationUser)
        {

            return new DentistDTO
            {
                Id = applicationUser.Id,
                Email = applicationUser.Email,
                FirstName = applicationUser.FirstName,
                LastName = applicationUser.LastName,
                PhoneNumber = applicationUser.PhoneNumber,
                AffiliateDTO = applicationUser.Affiliate is null ? null : AffiliateMapper.AffiliateToDTO(applicationUser.Affiliate),
            };
        }

        public static ApplicationUser DTOtoApplicationUser(DentistDTO dentistDTO)
        {
            return new ApplicationUser
            {
                Email = dentistDTO.Email,
                UserName = dentistDTO.Email,
                FirstName = dentistDTO.FirstName,
                LastName = dentistDTO.LastName,
                PhoneNumber = dentistDTO.PhoneNumber,
                NormalizedUserName = dentistDTO.Email.ToUpper(),
                NormalizedEmail = dentistDTO.Email.ToUpper(),
                EmailConfirmed = true,
                UserRoles = new List<ApplicationUserRole>()
            };
        }

        public static DentistViewModel DTOtoDentistViewModel(DentistDTO dentistDTO)
        {
            return new DentistViewModel
            {
                Id = dentistDTO.Id,
                FirstName = dentistDTO.FirstName,
                LastName = dentistDTO.LastName,
                FullName = dentistDTO.FirstName + " " + dentistDTO.LastName,
                Email = dentistDTO.Email,
                PhoneNumber = dentistDTO.PhoneNumber,
                Affiliate = dentistDTO.AffiliateDTO?.Name
            };
        }
    }
}
