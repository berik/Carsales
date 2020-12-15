using System;
using System.IO;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace Core.Services
{
    public class StorageService : IStorageService
    {
        private readonly string _storageConnectionString;
        private readonly string _storageImageContainer;
        
        public StorageService(IConfiguration configuration)
        {
            _storageConnectionString = configuration.GetConnectionString("AzureStorageConnection");
            _storageImageContainer = configuration["AzureStorage:ImageContainer"];
        }
        
        public async Task<BlobClient> UploadImageToStorage(string ownerId, IFormFile image)
        {
            // The BlobServiceClient class allows you to manipulate Azure Storage resources and blob containers
            var blobServiceClient = new BlobServiceClient(_storageConnectionString);

            // The BlobContainerClient class allows you to manipulate Azure Storage containers and their blobs.
            var blobContainerClient = blobServiceClient.GetBlobContainerClient(_storageImageContainer);

            // Create a local file in the ./data/ directory for uploading and downloading
            var fileName = Guid.NewGuid() + Path.GetExtension(image.FileName);
            var filePath = $"{ownerId}/{fileName}";

            // The BlobClient class allows you to manipulate Azure Storage blobs.
            var blobClient = blobContainerClient.GetBlobClient(filePath);

            // Open the file and upload its data
            await using var uploadFileStream = image.OpenReadStream();
            await blobClient.UploadAsync(uploadFileStream);
            uploadFileStream.Close();
            return blobClient;
        }
    }
}