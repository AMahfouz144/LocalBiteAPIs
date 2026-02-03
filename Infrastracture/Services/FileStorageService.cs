using Application.Infrastructure;
using Microsoft.AspNetCore.Http;


namespace Infrastracture.Services
{
    internal class FileStorageService : IFileStorageService
    {
        public async Task<string> SaveFileAsync(IFormFile file, string folder)
        {
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName)}";
            var filePath = Path.Combine("wwwroot", folder, fileName);

            Directory.CreateDirectory(Path.GetDirectoryName(filePath)!);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return $"/{folder}/{fileName}";
        }

    }
}
