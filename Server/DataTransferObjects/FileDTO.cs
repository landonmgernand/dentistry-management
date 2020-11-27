using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DentistryManagement.Server.DataTransferObjects
{
    public class FileDTO
    {
        public int Id { get; set; }

        public string Path { get; set; }

        public DateTime UploadDT { get; set; }
    }
}
