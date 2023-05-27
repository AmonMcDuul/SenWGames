using SenWGames.Core.Common;
using System.Linq.Expressions;

namespace SenWGames.Core.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
        Task SaveAsync();
    }
}
