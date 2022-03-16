using ESourcing.Sourcings.Entities;

namespace ESourcing.Sourcing.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(string id);
        Task Create(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(string id);
    }
}
