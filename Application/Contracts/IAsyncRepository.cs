namespace ActivityApp.Application.Contracts
{
    public interface IAsyncRepository<T> where T : class
    {
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T?> GetByIdAsync(Guid id);
        Task<T> AddAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}