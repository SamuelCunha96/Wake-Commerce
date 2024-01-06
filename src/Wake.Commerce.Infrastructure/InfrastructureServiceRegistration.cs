using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Wake.Commerce.Infrastructure.Context;
using Wake.Commerce.Infrastructure.Interfaces.Repositories;
using Wake.Commerce.Infrastructure.Repositories;

namespace Wake.Commerce.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<WakeCommerceContext>(options =>
                    options.UseInMemoryDatabase("CommerceDb"));

            services.AddScoped<IProdutoRepository, ProdutoRepository>();

            return services;
        }
    }
}
