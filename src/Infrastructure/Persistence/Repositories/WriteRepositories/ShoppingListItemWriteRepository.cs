using Application.Contracts.Repositories.WriteRepositories;
using Domain;

namespace Persistence.Repositories.WriteRepositories
{
    public class ShoppingListItemWriteRepository : GenericWriteRepository<ShoppingListItem>, IShoppingListItemWriteRepository
    {
        public ShoppingListItemWriteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
