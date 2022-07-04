namespace Application.Dtos
{
    public class ShoppingListDto
    {
        public string Name { get; set; }
        public CategoryDto Category { get; set; }
        public ICollection<ShoppingListItemDto> ShoppingListItems { get; set; }
        public string Note { get; set; }
        public bool IsCompleted { get; set; }
    }
}
