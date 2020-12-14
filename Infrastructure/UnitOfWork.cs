using System.Threading.Tasks;
using Core.Interfaces.IData;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public ICarRepository CarRepository { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            CarRepository = new CarRepository(_context);
        }
        
        public void Dispose()
        {
            _context.Dispose();
        }
        
        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}