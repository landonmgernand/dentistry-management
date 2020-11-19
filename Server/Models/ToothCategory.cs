using System.Collections.Generic;

namespace DentistryManagement.Server.Models
{
    public class ToothCategory
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Teeth> Teeth { get; set; }
    }
}
