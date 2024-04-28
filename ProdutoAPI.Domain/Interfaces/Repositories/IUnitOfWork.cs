namespace ProdutoAPI.Domain.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    public IProdutoRepository ProdutoRepository { get; }
    void SaveChanges();
}