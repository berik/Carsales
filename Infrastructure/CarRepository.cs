using Core.Entities;
using Core.Interfaces.IData;

namespace Infrastructure
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}