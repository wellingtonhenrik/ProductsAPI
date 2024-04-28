using Microsoft.Extensions.Options;
using MongoDB.Driver;
using ProdutosAPI.Application.Models.Queries;
using ProdutosAPI.Infra.Data.MongoDB.Settings;

namespace ProdutosAPI.Infra.Data.MongoDB.Contexts
{
    public class MongoDBContext
    {
        private readonly MongoDBSettings _mongoDBSettings;
        private IMongoDatabase? _mongoDatabase;
        public MongoDBContext(IOptions<MongoDBSettings> mongoDBSettings)
        {
            _mongoDBSettings = mongoDBSettings.Value;

            #region Conexão com o banco de dados 

            var client = MongoClientSettings.FromUrl(new MongoUrl(_mongoDBSettings.Host));
            if (_mongoDBSettings.IsSSL)
            {
                client.SslSettings = new SslSettings
                {
                    EnabledSslProtocols = System.Security.Authentication.SslProtocols.Tls12,
                };
            }

            _mongoDatabase = new MongoClient(client).GetDatabase(_mongoDBSettings.Nome);
            #endregion
        }

        public IMongoCollection<ProdutosDTO> Produtos => _mongoDatabase.GetCollection<ProdutosDTO>("Produtos");


    }
}
