using Application.Contracts.Repositories.ReadRepositories;
using Domain;

namespace Persistence.Repositories.ReadRepositories
{
    public class CategoryReadRepository : GenericReadRepository<Category>, ICategoryReadRepository
    {
        public CategoryReadRepository(AppDbContext context) : base(context)
        {

        }
    }
}
