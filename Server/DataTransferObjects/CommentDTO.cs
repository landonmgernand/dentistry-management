using DentistryManagement.Server.Models;
using System;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class CommentDTO
    {
        public int Id { get; set; }

        public int ToothId { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public ApplicationUser User { get; set; }
    }
}
