using System;
using System.ComponentModel.DataAnnotations;

namespace DentistryManagement.Shared.ViewModels.Files
{
    public class FileViewModel
    {
        public int Id { get; set; }

        public string Path { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime UploadDT { get; set; }
    }
}
