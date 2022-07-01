using Main.Models;
using Main.Specifications;

namespace Main.Interfaces
{
    public interface IGenericRepository<T> where T: BaseModel
    {
        Task<T> GetByIdAsync(int id);
        Task<IReadOnlyList<T>> ListAllAsync();    
        Task<T> GetEntityWithSpec(ISpecification<T> spec);    
        Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}