using Core.Entities;

namespace Entities.Concrete
{
    public class Shop : IEntity
    {
        public int ShopId { get; set; }
        public string ShopName { get; set; }
    }
}
