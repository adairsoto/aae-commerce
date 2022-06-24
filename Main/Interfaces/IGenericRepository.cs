using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}