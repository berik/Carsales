using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Core.Interfaces.IServices
{
    public interface ICarService
    {
        Task<Car> AddCar(Car car, string ownerId, IFormFile image);
    }
}