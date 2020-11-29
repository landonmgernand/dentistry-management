using System;

namespace DentistryManagement.Server.Models
{
    public class File
    {
        public int Id { get; set; }

        public string Filename { get; set; }

        public string Path { get; set; }

        public string Extension { get; set; }

        public int Filesize { get; set; }

        public int MedicalChartId { get; set; }

        public MedicalChart MedicalChart { get; set; }

        public DateTime UploadDT { get; set; }
    }
}
