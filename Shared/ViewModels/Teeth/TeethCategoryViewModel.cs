using System.Collections.Generic;

namespace DentistryManagement.Shared.ViewModels.Teeth
{
    public class TeethCategoryViewModel
    {
        public List<ToothViewModel> UpperRight { get; set; }

        public List<ToothViewModel> UpperLeft { get; set; }

        public List<ToothViewModel> LowerRight { get; set; }

        public List<ToothViewModel> LowerLeft { get; set; }

        public List<ToothViewModel> All { get; set; }
    }
}
