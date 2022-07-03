using Application.Contracts.Repositories.WriteRepositories;
using Domain;
namespace Persistence.Repositories.WriteRepositories
{
    public class StockUnitWriteRepository : GenericWriteRepository<StockUnit>, IStockUnitWriteRepository
    {
        public StockUnitWriteRepository(AppDbContext context) : base(context)
        {

        }
    }
}
