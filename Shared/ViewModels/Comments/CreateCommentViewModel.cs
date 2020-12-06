using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared.ViewModels.Comments
{
    public class CreateCommentViewModel
    {
        [Required]
        public int ToothId { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string Text { get; set; }
    }
}
