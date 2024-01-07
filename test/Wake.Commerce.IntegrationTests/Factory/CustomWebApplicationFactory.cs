using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wake.Commerce.Domain.Entities;
using Wake.Commerce.Infrastructure.Context;

namespace Wake.Commerce.IntegrationTests.Factory
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<WakeCommerceContext>));
                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                services.AddDbContext<WakeCommerceContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var db = scopedServices.GetRequiredService<WakeCommerceContext>();
                    db.Database.EnsureCreated();

                    SeedFakeDatabase(db);
                }
            });
        }

        private void SeedFakeDatabase(WakeCommerceContext context)
        {
            context?.Produtos?.AddRangeAsync(
                new Produto { Nome = "Produto A", Estoque = 1, Valor = 10 },
                new Produto { Nome = "Produto B", Estoque = 1, Valor = 10 });
            context?.SaveChanges();
        }
    }
}
