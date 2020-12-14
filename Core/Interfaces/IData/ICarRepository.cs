using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces.IData
{
    public interface ICarRepository : IGenericRepository<Car>
    {
        Task<IReadOnlyList<Car>> GetAllAsync(string ownerId);
    }
}