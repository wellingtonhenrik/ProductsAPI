using Microsoft.EntityFrameworkCore;
using ProdutoAPI.Domain.Models;
using ProdutoAPI.Infra.Data.SqlServer.Configurations;

namespace ProdutoAPI.Infra.Data.SqlServer.Contexts;

public class DataContext : DbContext
{
    //construtor para injeção de dependecia 
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProdutoConfiguration());
    }

    DbSet<Produto> Produtos { get; set; }
}