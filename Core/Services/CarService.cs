using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Core.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStorageService _storageService;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarService(IUnitOfWork unitOfWork, IStorageService storageService, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _storageService = storageService;
            _userManager = userManager;
        }
        
        public async Task<Car> AddCar(Car car, string ownerId, IFormFile image)
        {
            if (await _userManager.FindByIdAsync(ownerId) == null) return null;
            car.OwnerId = ownerId;

            if (image != null)
            {
                var imageResult = await _storageService.UploadImageToStorage(ownerId, image);
                if (imageResult != null) car.Image = imageResult.Name;
            }
            
            var result = _unitOfWork.CarRepository.Add(car);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}