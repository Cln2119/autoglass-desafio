using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Api.Data.Mapping
{
    public class ProdutosMap : IEntityTypeConfiguration<ProdutosEntity>
    {
        public void Configure(EntityTypeBuilder<ProdutosEntity> builder)
        {
            builder.ToTable("Produtos");

            builder.HasKey(produto => produto.Id);

            builder.Property(produto => produto.Id)
                   .IsRequired()
                   .UseIdentityColumn();

            builder.Property(produto => produto.Descricao)
                   .IsRequired()
                   .HasMaxLength(60);

            builder.Property(produto => produto.Situacao)
                   .HasMaxLength(100);

            builder.Property(produto => produto.DataFabricacao)
                   .HasMaxLength(100);

            builder.Property(produto => produto.DataValidade)
                   .HasMaxLength(100);

            builder.Property(produto => produto.CodigoFornecedor)
                   .HasMaxLength(100);

            builder.Property(produto => produto.DescricaoFornecedor)
                   .HasMaxLength(100);

            builder.Property(produto => produto.CnpjFornecedor)
                   .HasMaxLength(100);
        }
    }
}
