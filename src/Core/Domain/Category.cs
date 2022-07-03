using Domain.Common;

namespace Domain
{
    public class Category : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public ICollection<ShoppingList> ShoppingLists { get; set; }
    }
}
