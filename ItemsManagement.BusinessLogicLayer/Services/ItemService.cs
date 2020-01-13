using ItemsManagement.BusinessLogicLayer.Models.ItemModels;
using ItemsManagement.BusinessLogicLayer.Services.Interfaces;
using ItemsManagement.DataAccessLayer.Entities;
using ItemsManagement.DataAccessLayer.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StatisticModelDAL = ItemsManagement.DataAccessLayer.Models.StatisticModel;

namespace ItemsManagement.BusinessLogicLayer.Services
{
    public class ItemService : IItemService
    {
        private readonly IItemRepository _itemRepository;
        public ItemService(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task CreateAsync(ItemModel itemModel)
        {
            Item item = itemModel.MapToEntity();

            await _itemRepository.CreateAsync(item);
        }

        public async Task<List<ItemModel>> GetItemsAsync()
        {
            List<Item> items = await _itemRepository.GetAsync();

            List<ItemModel> itemModels = items.Select(item => new ItemModel(item)).ToList();

            return itemModels;
        }

        public async Task<ItemListResponseModel> GetItemsListAsync(ItemRequestModel requestModel)
        {
            (int count, List<Item> items) = await _itemRepository.GetItemsListAsync(requestModel.PageNumber);

            ItemListResponseModel responseModel = new ItemListResponseModel
            {
                TotalCount = count,
                ItemModels = items.Select(item => new ItemModel(item)).ToList()
            };

            return responseModel;
        }

        public async Task<ItemStatisticResponseModel> GetItemStatisticAsync(ItemRequestModel requestModel)
        {
            (int count, List<StatisticModelDAL> statisticModels) = await _itemRepository.GetItemStatisticAsync(requestModel.PageNumber);

            ItemStatisticResponseModel response = new ItemStatisticResponseModel {
                TotalCount = count,
                StatisticModels = statisticModels.Select(statisticModelDAL => new StatisticModel { 
                    Type = statisticModelDAL.Type, 
                    Count = statisticModelDAL.Count }).ToList()
            };

            return response;
        }

        public async Task RemoveAsync(ItemModel itemModel)
        {
            Item item = await _itemRepository.GetByIdAsync(itemModel.Id);

            await _itemRepository.RemoveAsync(item);
        }

        public async Task UpdateAsync(ItemModel itemModel)
        {

            Item item = await _itemRepository.GetByIdAsync(itemModel.Id);
            item.Name = itemModel.Name;
            item.Type = itemModel.Type;

            await _itemRepository.UpdateAsync(item);
        }
    }
}
