using DentistryManagement.Server.DataTransferObjects;

namespace DentistryManagement.Server.Services.Interfaces
{
    public interface ICommentService
    {
        public void Create(CommentDTO commentDTO);
        public bool Exist(int toothId, int id);
        public void Delete(int id);
    }
}
