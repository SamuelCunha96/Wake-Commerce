using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wake.Commerce.Repository.Context;
using Wake.Commerce.Repository.Interfaces.Repositories;
using Wake.Commerce.Repository.Repositories;

namespace Wake.Commerce.Repository
{
    public static class RepositoryServiceRegistration
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WakeCommerceContext>(options =>
                    options.UseInMemoryDatabase("CommerceDb"));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
