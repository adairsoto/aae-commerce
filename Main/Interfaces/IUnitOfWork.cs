using Main.Models;

namespace Main.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseModel;
        Task<int> Complete();
    }
}