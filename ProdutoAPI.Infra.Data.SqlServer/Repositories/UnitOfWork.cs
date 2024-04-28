using ProdutoAPI.Domain.Interfaces.Repositories;
using ProdutoAPI.Infra.Data.SqlServer.Contexts;

namespace ProdutoAPI.Infra.Data.SqlServer.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public IProdutoRepository ProdutoRepository => new ProdutoRepository(_dataContext);

        public void Dispose()
        {
            _dataContext.Dispose();
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }
    }
}
