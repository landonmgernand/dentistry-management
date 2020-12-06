using DentistryManagement.Server.Data;
using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Helpers;
using DentistryManagement.Server.Mappers;
using DentistryManagement.Server.Services.Interfaces;
using System;
using System.Linq;

namespace DentistryManagement.Server.Services
{
    public class CommentService : ICommentService
    {
        private readonly ApplicationDbContext _context;
        private readonly UserProviderService _userProvider;

        public CommentService(ApplicationDbContext context, UserProviderService userProviderService)
        {
            _context = context;
            _userProvider = userProviderService;
        }

        public void Create(CommentDTO commentDTO)
        {
            var tooth = _context.Teeth.Find(commentDTO.ToothId);
            var comment = CommentMapper.DTOtoComment(commentDTO);
            comment.Tooth = tooth;
            comment.Created = DateTime.Now;
            comment.UserId = _userProvider.GetUserId();
            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = _context.Comments.Find(id);
            _context.Comments.Remove(comment);
            _context.SaveChanges();
        }

        public bool Exist(int toothId, int id)
        {
            return _context.Comments.Any(c => c.Id.Equals(id) && c.ToothId.Equals(toothId));
        }
    }
}
