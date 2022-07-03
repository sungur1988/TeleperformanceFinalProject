using Domain.Common;

namespace Domain
{
    public class ShoppingList : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public ICollection<ShoppingListItem> ShoppingListItems { get; set; }
        public string Note { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }
    }
}
