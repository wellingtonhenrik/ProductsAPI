using ProdutoAPI.Domain.Interfaces.Repositories;
using ProdutoAPI.Domain.Models;
using ProdutoAPI.Infra.Data.SqlServer.Contexts;

namespace ProdutoAPI.Infra.Data.SqlServer.Repositories;

public class ProdutoRepository : BaseRepository<Produto,Guid>, IProdutoRepository
{

    private DataContext? _dataContext;

    public ProdutoRepository(DataContext? dataContext) : base(dataContext)
    {
        _dataContext = dataContext;
    }    
}