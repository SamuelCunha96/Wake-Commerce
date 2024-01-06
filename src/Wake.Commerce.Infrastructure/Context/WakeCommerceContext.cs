using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;
using Wake.Commerce.Domain.Entities;

namespace Wake.Commerce.Infrastructure.Context
{
    public class WakeCommerceContext : DbContext
    {
        public DbSet<Produto>? Produtos { get; set; }

        public WakeCommerceContext([NotNull] DbContextOptions<WakeCommerceContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WakeCommerceContext).Assembly);
        }
    }
}
