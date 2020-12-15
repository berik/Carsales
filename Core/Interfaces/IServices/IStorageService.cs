using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.IServices
{
    public interface IStorageService
    {
        Task<BlobClient> UploadImageToStorage(string ownerId, IFormFile image);
    }
}