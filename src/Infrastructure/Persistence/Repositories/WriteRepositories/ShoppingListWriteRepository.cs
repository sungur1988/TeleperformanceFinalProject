using Application.Contracts.Repositories.WriteRepositories;
using Domain;

namespace Persistence.Repositories.WriteRepositories
{
    public class ShoppingListWriteRepository : GenericWriteRepository<ShoppingList>, IShoppingListWriteRepository
    {
        public ShoppingListWriteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
