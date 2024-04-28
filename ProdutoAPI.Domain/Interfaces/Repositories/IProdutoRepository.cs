using ProdutoAPI.Domain.Models;

namespace ProdutoAPI.Domain.Interfaces.Repositories;

public interface IProdutoRepository : IBaseRepository<Produto, Guid>
{
    
}