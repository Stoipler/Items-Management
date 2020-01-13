using ItemsManagement.DataAccessLayer.AppContext;
using ItemsManagement.DataAccessLayer.Entities.Interfaces;
using ItemsManagement.DataAccessLayer.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemsManagement.DataAccessLayer.Repositories.EntityFrameworkRepositories.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IBaseEntity
    {
        protected ApplicationContext _applicationContext;
        protected DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
            _dbSet = applicationContext.Set<TEntity>();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            await _applicationContext.SaveChangesAsync();
        }

        public async Task<List<TEntity>> GetAsync()
        {
            List<TEntity> list = await _dbSet.ToListAsync();

            return list;
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            TEntity entity = await _dbSet.FindAsync(id);

            return entity;
        }

        public async Task RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);

            await _applicationContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _applicationContext.Entry(entity).State = EntityState.Modified;

            await _applicationContext.SaveChangesAsync();
        }
    }
}
