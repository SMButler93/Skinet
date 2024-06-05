using Core.Entities;
using Core.Specifications;

namespace Core.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IReadOnlyList<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<T> GetEntityBySpecAsync(ISpecification<T> spec);
        Task<IReadOnlyList<T>> ListAllBySpecAsync(ISpecification<T> spec);
    }
}