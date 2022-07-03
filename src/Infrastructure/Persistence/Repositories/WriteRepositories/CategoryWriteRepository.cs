using Application.Contracts.Repositories.WriteRepositories;
using Domain;

namespace Persistence.Repositories.WriteRepositories
{
    public class CategoryWriteRepository : GenericWriteRepository<Category>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
