using System.Collections.Generic;

namespace ItemsManagement.BusinessLogicLayer.Models.ItemModels
{
    public class ItemListResponseModel
    {
        public List<ItemModel> ItemModels { get; set; }
        public int TotalCount { get; set; }

        public ItemListResponseModel()
        {
            ItemModels = new List<ItemModel>();
        }
    }
}
