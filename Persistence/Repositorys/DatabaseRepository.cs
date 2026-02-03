using Application.Persistence.IRepositories;
using Persistence.Core;

namespace Persistence.Repositories
{
    public class DatabaseRepository : IDatabaseRepository
    {
        private readonly AppDbContext _context;

        public DatabaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}