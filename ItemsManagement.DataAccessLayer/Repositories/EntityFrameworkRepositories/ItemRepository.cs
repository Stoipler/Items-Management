using ItemsManagement.DataAccessLayer.AppContext;
using ItemsManagement.DataAccessLayer.Entities;
using ItemsManagement.DataAccessLayer.Models;
using ItemsManagement.DataAccessLayer.Repositories.EntityFrameworkRepositories.Base;
using ItemsManagement.DataAccessLayer.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ItemsManagement.DataAccessLayer.Repositories.EntityFrameworkRepositories
{
    public class ItemRepository : BaseRepository<Item>, IItemRepository
    {
        public ItemRepository(ApplicationContext applicationContext) : base(applicationContext)
        {
        }

        public async Task<(int, List<Item>)> GetItemsListAsync(int pageNumber)
        {
            IQueryable<Item> items = _dbSet.OrderByDescending(item => item.Id);
            int totalCount = await items.CountAsync();

            if (pageNumber == default(int))
            {
                pageNumber = 1;
            }
            int pageSize = 4;
            int countToSkip = (--pageNumber) * pageSize;

            items = items.Skip(countToSkip).Take(pageSize);

            var response = await items.ToListAsync();

            return (totalCount, response);
        }

        public async Task<(int,List<StatisticModel>)> GetItemStatisticAsync(int pageNumber)
        {
            IQueryable<string> types = _dbSet.Select(item => item.Type).Distinct();

            int totalCount = await types.CountAsync();

            IQueryable<StatisticModel> statisticModelsQuery = types.Select(type => new StatisticModel
            {
                Type = type,
                Count = _dbSet.Where(item => item.Type == type).Count()
            });

            if (pageNumber == default(int))
            {
                pageNumber = 1;
            }
            int pageSize = 3;
            int countToSkip = (--pageNumber) * pageSize;

            statisticModelsQuery = statisticModelsQuery.Skip(countToSkip).Take(pageSize);

            List<StatisticModel> statisticModels = await statisticModelsQuery.ToListAsync();

            return (totalCount, statisticModels);
        }
    }
}
