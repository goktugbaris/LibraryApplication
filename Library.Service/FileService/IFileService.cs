using Microsoft.AspNetCore.Http;

namespace Library.Service.FileService
{
    public interface IFileService
    {
        Task<(string pathName, string fileName)> WriteFile(IFormFile file);
        void RemoveFile(string pathName);
    }
}
