using System.Collections.Generic;

namespace ItemsManagement.BusinessLogicLayer.Models.ItemModels
{
    public class ItemStatisticResponseModel
    {
        public List<StatisticModel> StatisticModels { get; set; }
        public int TotalCount { get; set; }
    }
}
