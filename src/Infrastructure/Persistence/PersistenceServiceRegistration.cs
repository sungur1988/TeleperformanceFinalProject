using Application.Contracts.Repositories.ReadRepositories;
using Application.Contracts.Repositories.WriteRepositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories.ReadRepositories;
using Persistence.Repositories.WriteRepositories;

namespace Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });
            services.AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>));

            services.AddScoped<IShoppingListWriteRepository, ShoppingListWriteRepository>();
            services.AddScoped<IShoppingListReadRepository, ShoppingListReadRepository>();

            services.AddScoped<IShoppingListItemWriteRepository, ShoppingListItemWriteRepository>();
            services.AddScoped<IShoppingListItemReadRepository, ShoppingListItemReadRepository>();

            services.AddScoped<ICategoryWriteRepository, CategoryWriteRepository>();
            services.AddScoped<ICategoryReadRepository, CategoryReadRepository>();

            services.AddScoped<IStockUnitWriteRepository, StockUnitWriteRepository>();
            services.AddScoped<IStockUnitReadRepository, StockUnitReadRepository>();

            return services;

        }
    }
}
