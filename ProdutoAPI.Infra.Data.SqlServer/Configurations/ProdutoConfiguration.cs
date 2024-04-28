using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProdutoAPI.Domain.Models;

namespace ProdutoAPI.Infra.Data.SqlServer.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Preco).HasColumnType("decimal(18,2)").IsRequired();
        builder.Property(x=>x.Quantidade).IsRequired();
        builder.Property(x=>x.Nome).HasMaxLength(150).IsRequired();
        builder.Property(x => x.DataCriacao).IsRequired();
    }
}