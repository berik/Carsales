using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;
using Microsoft.AspNetCore.Identity;

namespace Core.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<ApplicationUser> _userManager;

        public CarService(IUnitOfWork unitOfWork, UserManager<ApplicationUser> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }
        
        public async Task<Car> AddCar(Car car, string ownerId)
        {
            if (await _userManager.FindByIdAsync(ownerId) == null) return null;
            car.OwnerId = ownerId;
            var result = _unitOfWork.CarRepository.Add(car);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}