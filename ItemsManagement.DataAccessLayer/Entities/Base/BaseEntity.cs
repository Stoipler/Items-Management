using ItemsManagement.DataAccessLayer.Entities.Interfaces;

namespace ItemsManagement.DataAccessLayer.Entities.Base
{
    public class BaseEntity : IBaseEntity
    {
        public int Id { get; set; }
    }
}
