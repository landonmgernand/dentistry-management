using DentistryManagement.Server.DataTransferObjects;
using DentistryManagement.Server.Models;

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
    }
}
