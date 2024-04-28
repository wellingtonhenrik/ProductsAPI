using MongoDB.Driver;
using ProdutosAPI.Application.Interfaces.Stores;
using ProdutosAPI.Application.Models.Queries;
using ProdutosAPI.Infra.Data.MongoDB.Contexts;

namespace ProdutosAPI.Infra.Data.MongoDB.Stores
{
    public class ProdutosStore : IProdutosStore
    {
        private readonly MongoDBContext _mongoDBContext;

        public ProdutosStore(MongoDBContext mongoDBContext)
        {
            _mongoDBContext = mongoDBContext;
        }

        public void Add(ProdutosDTO item)
        {
            _mongoDBContext.Produtos.InsertOne(item);
        }

        public void Delete(Guid id)
        {
            var filter = Builders<ProdutosDTO>.Filter.Eq(p => p.id, id);
            _mongoDBContext.Produtos.DeleteOne(filter);
        }

        public List<ProdutosDTO> GetAll()
        {
            var filter = Builders<ProdutosDTO>.Filter.Where(p => true);
            return _mongoDBContext.Produtos.Find(filter).ToList();
        }

        public ProdutosDTO GetById(Guid id)
        {
            var filter = Builders<ProdutosDTO>.Filter.Eq(p => p.id, id);
            return _mongoDBContext.Produtos.Find(filter).FirstOrDefault();
        }

        public void Update(ProdutosDTO item)
        {
            var filter = Builders<ProdutosDTO>.Filter.Eq(p => p.id, item.id);
            _mongoDBContext.Produtos.ReplaceOne(filter, item);
        }
    }
}
