using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.IServices
{
    public interface ICarService
    {
        Task<Car> AddCar(Car car, string ownerId);
    }
}