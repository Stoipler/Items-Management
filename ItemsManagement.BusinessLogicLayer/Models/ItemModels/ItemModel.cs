using ItemsManagement.DataAccessLayer.Entities;

namespace ItemsManagement.BusinessLogicLayer.Models.ItemModels
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }

        public ItemModel()
        {
        }
        public ItemModel(Item entity) : this()
        {
            if (!(entity is null))
            {
                Id = entity.Id;
                Name = entity.Name;
                Type = entity.Type;
            }
        }

        internal Item MapToEntity()
        {
            Item entity = new Item();
            if (Id != default(int))
            {
                entity.Id = Id;
            }
            entity.Name = Name;
            entity.Type = Type;

            return entity;
        }
    }
}
