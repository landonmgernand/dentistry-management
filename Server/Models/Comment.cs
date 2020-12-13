using System;

namespace DentistryManagement.Server.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int ToothId { get; set; }

        public Tooth Tooth { get; set; }

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}
