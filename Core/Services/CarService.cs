using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.IData;
using Core.Interfaces.IServices;

namespace Core.Services
{
    public class CarService : ICarService
    {
        private readonly IUnitOfWork _unitOfWork;
        public CarService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Car> AddCar(Car car, string ownerId)
        {
            car.OwnerId = ownerId;
            var result = _unitOfWork.CarRepository.Add(car);
            await _unitOfWork.CompleteAsync();
            return result;
        }
    }
}