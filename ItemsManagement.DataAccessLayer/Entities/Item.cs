using ItemsManagement.DataAccessLayer.Entities.Base;

namespace ItemsManagement.DataAccessLayer.Entities
{
    public class Item:BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
    }
}
