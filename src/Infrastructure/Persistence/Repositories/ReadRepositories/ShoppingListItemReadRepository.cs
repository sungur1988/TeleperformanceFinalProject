using Application.Contracts.Repositories.ReadRepositories;
using Domain;

namespace Persistence.Repositories.ReadRepositories
{
    public class ShoppingListItemReadRepository : GenericReadRepository<ShoppingListItem>, IShoppingListItemReadRepository
    {
        public ShoppingListItemReadRepository(AppDbContext context) : base(context)
        {

        }
    }
}
