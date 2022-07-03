using Domain.Common;

namespace Domain
{
    public class StockUnit : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
    }
}
