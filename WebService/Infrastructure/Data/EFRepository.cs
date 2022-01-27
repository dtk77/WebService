using Microsoft.EntityFrameworkCore;
using WebService.ApplicationCore.Interfaces;

namespace WebService.Infrastructure.Data
{
    public class EFRepository<T> : IAsyncRepository<T> where T : class
    {
        protected readonly EFDbContext _dbContext;
        public EFRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<T>().ToListAsync(cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return entity;
        }

    }
}
