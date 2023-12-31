using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace Library.Service.FileService
{
    public class FileService : IFileService
    {
        private readonly IWebHostEnvironment _iWebHostEnvironment;

        public FileService(IWebHostEnvironment iWebHostEnvironment)
        {
            _iWebHostEnvironment = iWebHostEnvironment;
        }
        public void RemoveFile(string pathName)
        {
            var path = $"{_iWebHostEnvironment.ContentRootPath}/wwwroot/media/{pathName}";
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);

        }

        public async Task<(string pathName, string fileName)> WriteFile(IFormFile file)
        {
            var path = $"{_iWebHostEnvironment.ContentRootPath}/wwwroot/media/books";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var extenstion = Path.GetExtension(file.FileName);
            var savedFileName = CheckFileName(file.FileName) + extenstion;

            if (file != null)
            {
                var targetFile = $"{path}/{savedFileName}";
                using (var stream = new FileStream(targetFile, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            return (savedFileName, savedFileName);
        }

        public static string CheckFileName(string fileName)
        {
            string invalidCharsPattern = "[\\~#%&*{}!/:<>?|\"-]";
            string spacesPattern = "\\s+";

            string newFileName = Regex.Replace(fileName, invalidCharsPattern, "");
            newFileName = Regex.Replace(newFileName, spacesPattern, "_");

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(newFileName);

            if (string.IsNullOrEmpty(fileNameWithoutExtension))
            {
                fileNameWithoutExtension = "unknown_" + DateTime.Now.ToString("yyyyMMddHHmmss");
            }

            int maxLength = 100;
            if (fileNameWithoutExtension.Length > maxLength)
            {
                fileNameWithoutExtension = fileNameWithoutExtension.Substring(0, maxLength);
            }

            return fileNameWithoutExtension;
        }

    }
}
