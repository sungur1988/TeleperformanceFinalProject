using Application.Contracts.Repositories.ReadRepositories;
using Domain;

namespace Persistence.Repositories.ReadRepositories
{
    public class StockUnitReadRepository : GenericReadRepository<StockUnit>, IStockUnitReadRepository
    {
        public StockUnitReadRepository(AppDbContext context) : base(context)
        {

        }
    }
}
