using Domain.Common;

namespace Domain
{
    public class ShoppingListItem : IEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string StockUnit { get; set; }
        public int Amount { get; set; }
        public bool IsPurchased { get; set; }
    }
}
