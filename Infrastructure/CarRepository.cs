using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces.IData;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        public CarRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Car>> GetAllAsync(string ownerId)
        {
            return await Context.Cars.Where(a => a.OwnerId == ownerId).ToListAsync();
        }
    }
}