using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;
using DentistryManagement.Shared.ViewModels.MedicalChart;

namespace DentistryManagement.Server.Mappers
{
    public class MedicalChartMapper
    {
        public static MedicalChartDTO MedicalChartToDTO(MedicalChart medicalChart)
        {
            return new MedicalChartDTO
            {
                Id = medicalChart.Id,
            };
        }

        public static MedicalChartViewModel DTOtoMedicalChartVM(MedicalChartDTO medicalChartDTO)
        {
            return new MedicalChartViewModel
            {
                Id = medicalChartDTO.Id
            };
        }
    }
}
