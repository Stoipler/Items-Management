using ItemsManagement.DataAccessLayer.Entities;
using ItemsManagement.DataAccessLayer.Models;
using ItemsManagement.DataAccessLayer.Repositories.Interfaces.Base;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemsManagement.DataAccessLayer.Repositories.Interfaces
{
    public interface IItemRepository : IBaseRepository<Item>
    {
        Task<(int, List<Item>)> GetItemsListAsync(int pageNumber);
        Task<(int, List<StatisticModel>)> GetItemStatisticAsync(int pageNumber);
    }
}
