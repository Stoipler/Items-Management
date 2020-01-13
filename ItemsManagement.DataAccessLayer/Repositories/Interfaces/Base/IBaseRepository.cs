using ItemsManagement.DataAccessLayer.Entities.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemsManagement.DataAccessLayer.Repositories.Interfaces.Base
{
    public interface IBaseRepository<TEntity> where TEntity : IBaseEntity
    {
        Task<List<TEntity>> GetAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task CreateAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(TEntity entity);
    }
}
