using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProdutosAPI.Infra.Data.MongoDB.Contexts;
using ProdutosAPI.Infra.Data.MongoDB.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProdutoAPI.Infra.IoC.Extensions
{
    public static class MongoDBExtension
    {
        public static IServiceCollection AddMongoDBConfig(this IServiceCollection service, IConfiguration configuration)
        {
            service.Configure<MongoDBSettings>(configuration.GetSection("MongoDBSettings"));
            service.AddTransient<MongoDBContext>();
            return service;
        } 
    }
}
