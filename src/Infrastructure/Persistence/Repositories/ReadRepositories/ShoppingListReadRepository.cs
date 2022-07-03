using Application.Contracts.Repositories.ReadRepositories;
using Domain;

namespace Persistence.Repositories.ReadRepositories
{
    public class ShoppingListReadRepository : GenericReadRepository<ShoppingList>, IShoppingListReadRepository
    {
        public ShoppingListReadRepository(AppDbContext context) : base(context)
        {

        }
    }
}
