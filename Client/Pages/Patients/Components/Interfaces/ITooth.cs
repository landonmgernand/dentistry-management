using Microsoft.AspNetCore.Components;

namespace DentistryManagement.Client.Pages.Patients.Components.Interfaces
{
    public interface ITooth
    {
        RenderFragment ChildContent { get; }

        public int ToothId { get; }
    }
}
