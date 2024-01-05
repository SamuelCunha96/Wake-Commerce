using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Wake.Commerce.Domain.Entities;

namespace Wake.Commerce.Repository.Mapping
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("tb_produto");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .HasColumnName("id_produto")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Nome)
                .HasColumnName("nom_produto")
                .HasColumnType("int")
                .IsRequired();

            builder.Property(e => e.Estoque)
                .HasColumnName("qtd_estoque")
                .HasColumnType("smallint")
                .IsRequired();

            builder.Property(e => e.Valor)
                .HasColumnName("val_produto")
                .HasColumnType("decimal(9,2)")
                .IsRequired();
        }
    }
}
