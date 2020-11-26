using DentistryManagement.Server.Data;
using DentistryManagement.Server.Services.Interfaces;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;
using System.Linq;
using System;

namespace DentistryManagement.Server.Services
{
    public class FileService : IFileService
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _environment;

        public FileService(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        public async Task Create(int medicalChartId, IFormFile file)
        {
            var medicalChart = _context.MedicalCharts.SingleOrDefault(mc => mc.Id.Equals(medicalChartId));

            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var randomName = Path.GetRandomFileName().Replace(".", "") + extension;
            string path = Path.Combine(_environment.ContentRootPath, @"wwwroot\images\files");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path += "\\" + randomName;

            using var stream = new FileStream(path, FileMode.Create);
            await file.CopyToAsync(stream);

            _context.Files.Add(new Models.File()
            {
                Filename = Path.GetFileNameWithoutExtension(file.FileName),
                Path = randomName,
                Extension = extension,
                Filesize = (int)file.Length,
                UploadDT = DateTime.Now,
                MedicalChart = medicalChart
            });

            _context.SaveChanges();
        }
    }
}
