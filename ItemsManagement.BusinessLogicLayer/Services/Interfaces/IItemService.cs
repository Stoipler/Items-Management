using ItemsManagement.BusinessLogicLayer.Models.ItemModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ItemsManagement.BusinessLogicLayer.Services.Interfaces
{
    public interface IItemService
    {
        Task CreateAsync(ItemModel itemModel);
        Task UpdateAsync(ItemModel itemModel);
        Task RemoveAsync(ItemModel itemModel);
        Task<List<ItemModel>> GetItemsAsync();
        Task<ItemListResponseModel> GetItemsListAsync(ItemRequestModel requestModel);
        Task<ItemStatisticResponseModel> GetItemStatisticAsync(ItemRequestModel requestModel);
    }
}
