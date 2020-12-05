using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.Comments;

namespace DentistryManagement.Server.Mappers
{
    public class CommentMapper
    {
        public static CommentDTO CreateCommentVMToDTO(CreateCommentViewModel createComment)
        {
            return new CommentDTO
            {
                ToothId = createComment.ToothId,
                Text = createComment.Text,
            };
        }

        public static CommentViewModel DTOtoCommentVM(CommentDTO commentDTO)
        {
            return new CommentViewModel
            {
                Id = commentDTO.Id,
                Text = commentDTO.Text,
                Created = commentDTO.Created.ToString("dd-MM-yyyy"),
                User = commentDTO.User.FirstName + " " + commentDTO.User.LastName,
            };
        }

        public static CommentDTO CommentToDTO(Comment comment)
        {
            return new CommentDTO
            {
                Id = comment.Id,
                Text = comment.Text,
                User = comment.User,
                Created = comment.Created
            };
        }

        public static Comment DTOtoComment(CommentDTO commentDTO)
        {
            return new Comment
            {
                Text = commentDTO.Text
            };
        }
    }
}
