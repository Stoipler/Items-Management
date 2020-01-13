using ItemsManagement.BusinessLogicLayer.Models.ItemModels;
using ItemsManagement.BusinessLogicLayer.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ItemsManagement.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ItemController : ControllerBase
    {
        private readonly IItemService _itemService;

        public ItemController(IItemService itemService)
        {
            _itemService = itemService;
        }

        [HttpPost(Name = "GetItemsList")]
        public async Task<ItemListResponseModel> GetItemsList([FromBody]ItemRequestModel requestModel)
        {
            ItemListResponseModel responseModel = await _itemService.GetItemsListAsync(requestModel);

            return responseModel;
        }
        [HttpPost(Name = "CreateItem")]
        public async Task CreateItem([FromBody]ItemModel itemModel)
        {
            await _itemService.CreateAsync(itemModel);
        }
        [HttpPost(Name = "UpdateItem")]
        public async Task UpdateItem([FromBody]ItemModel itemModel)
        {
            await _itemService.UpdateAsync(itemModel);
        }
        [HttpPost(Name ="RemoveItem")]
        public async Task RemoveItem([FromBody]ItemModel itemModel)
        {
            await _itemService.RemoveAsync(itemModel);
        }
        [HttpPost(Name ="GetItemsStatistic")]
        public async Task<ItemStatisticResponseModel> GetItemsStatistic([FromBody]ItemRequestModel requestModel)
        {
            ItemStatisticResponseModel responseModel = await _itemService.GetItemStatisticAsync(requestModel);

            return responseModel;
        }
    }
}
