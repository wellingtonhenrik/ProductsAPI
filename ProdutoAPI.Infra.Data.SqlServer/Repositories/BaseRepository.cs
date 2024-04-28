using ProdutoAPI.Domain.Interfaces.Repositories;
using ProdutoAPI.Infra.Data.SqlServer.Contexts;

namespace ProdutoAPI.Infra.Data.SqlServer.Repositories
{
    public abstract class BaseRepository<TEntity, TKey> : IBaseRepository<TEntity, TKey>
        where TEntity : class
    {

        private readonly DataContext? _dataContext;

        protected BaseRepository(DataContext? dataContext)
        {
            _dataContext = dataContext;
        }
        public virtual void Add(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _dataContext.Set<TEntity>().Remove(entity);
        }

        public virtual void Dispose()
        {
            _dataContext.Dispose();
        }

        public virtual List<TEntity> GetAll()
        {
            return _dataContext.Set<TEntity>().ToList();
        }

        public virtual TEntity GetById(TKey id)
        {
            return _dataContext.Set<TEntity>().Find(id);
        }

        public void SaveChanges()
        {
            _dataContext.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            _dataContext?.Set<TEntity>().Update(entity);
        }
    }
}
