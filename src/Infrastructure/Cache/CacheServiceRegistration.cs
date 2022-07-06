using Application.Contracts.Cache;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cache
{
    public static class CacheServiceRegistration
    {
        public static IServiceCollection AddCacheService(this IServiceCollection services)
        {
            services.AddMemoryCache();
            services.AddScoped<ICacheManager,MemoryCacheManager>();
           
            return services;
        }
    }
}
