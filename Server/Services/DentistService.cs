using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using DentistryManagement.Server.Helpers;
using Microsoft.EntityFrameworkCore;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;

namespace DentistryManagement.Server.Services
{
    public class DentistService : IDentistService
    {
        private readonly ApplicationDbContext _context;
        private readonly IUserProviderService _userProviderService;

        public DentistService(ApplicationDbContext context, IUserProviderService userProviderService)
        {
            _context = context;
            _userProviderService = userProviderService;
        }

        public void Create(DentistDTO dentistDTO)
        {
            var dentist = DentistMapper.DTOtoApplicationUser(dentistDTO);
            PasswordHasher<ApplicationUser> passwordHasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = passwordHasher.HashPassword(dentist, dentistDTO.Password);

            dentist.PasswordHash = passwordHash;

            _context.ApplicationUsers.Add(dentist);

            var role = _context.ApplicationRole.Where(r => r.Name.Equals("Dentist")).Single();

            dentist.UserRoles.Add(new ApplicationUserRole()
            {
                User = dentist,
                Role = role,
            });

            var userId = _userProviderService.GetUserId();

            var affiliateId = _context.ApplicationUsers
                .Where(u => u.Id.Equals(userId))
                .Select(u => u.AffiliateId)
                .Single();

            var affiliate = _context.Affiliates.Find(affiliateId);
            dentist.Affiliate = affiliate;

            _context.SaveChanges();
        }

        public void Delete(string id)
        {
            var dentist = _context.ApplicationUsers.Find(id);
            _context.ApplicationUsers.Remove(dentist);
            _context.SaveChanges();
        }

        public bool Exist(string id)
        {
            return _context.ApplicationUsers.Any(x => x.Id.Equals(id));
        }

        public DentistDTO Get(string id)
        {
            var applicationUser = _context.ApplicationUsers
                 .Include(ur => ur.UserRoles)
                 .ThenInclude(r => r.Role)
                 .Include(a => a.Affiliate)
                 .SingleOrDefault(x => x.Id.Equals(id));

            if (applicationUser == null)
            {
                return null;
            }

            return DentistMapper.ApplicationUserToDTO(applicationUser);
        }

        public List<DentistDTO> GetAll()
        {
            var userId = _userProviderService.GetUserId();

            var affiliateId = _context.ApplicationUsers
                .Where(u => u.Id.Equals(userId))
                .Select(u => u.AffiliateId)
                .Single();

            var dentists = _context.ApplicationUsers
                .Include(ur => ur.UserRoles)
                .ThenInclude(r => r.Role)
                .Where(r => r.UserRoles.Any(r => r.Role.Name.Equals("Dentist")))
                .Include(a => a.Affiliate)
                .Where(a => a.Affiliate.Id.Equals(affiliateId))
                .Select(x => DentistMapper.ApplicationUserToDTO(x))
                .ToList();

            return dentists;
        }

        public DentistDTO GetByUsername(string username)
        {
            var applicationUser = _context.ApplicationUsers
                .Include(ur => ur.UserRoles)
                .ThenInclude(r => r.Role)
                .Include(a => a.Affiliate)
                .SingleOrDefault(x => x.UserName.Equals(username));

            if (applicationUser == null)
            {
                return null;
            }

            return DentistMapper.ApplicationUserToDTO(applicationUser);
        }

        public DentistDTO GetCurrent()
        {
            var userId = _userProviderService.GetUserId();

            var applicationUser = _context.ApplicationUsers
                .Include(ur => ur.UserRoles)
                .ThenInclude(r => r.Role)
                .Include(a => a.Affiliate)
                .SingleOrDefault(x => x.Id.Equals(userId));

            if (applicationUser == null)
            {
                return null;
            }

            return DentistMapper.ApplicationUserToDTO(applicationUser);
        }

        public void Update(DentistDTO userDTO)
        {
            var applicationUser = _context.ApplicationUsers
                .SingleOrDefault(x => x.Id.Equals(userDTO.Id));

            applicationUser.FirstName = userDTO.FirstName;
            applicationUser.LastName = userDTO.LastName;
            applicationUser.PhoneNumber = userDTO.PhoneNumber;

            _context.SaveChanges();
        }
    }
}
