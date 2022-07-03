using Domain.Common;

namespace Domain
{
    public class ShoppingListItem : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public StockUnit StockUnit { get; set; }
        public int Amount { get; set; }
        public bool IsPurchased { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
