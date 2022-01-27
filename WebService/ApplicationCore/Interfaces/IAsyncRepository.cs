using System.Threading;

namespace WebService.ApplicationCore.Interfaces
{
    /// <summary>
    /// Interface for implementing the repository
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> GetAsync(CancellationToken cancellationToken = default);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken = default);
    }
}
