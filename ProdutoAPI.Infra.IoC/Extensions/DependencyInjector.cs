using Microsoft.Extensions.DependencyInjection;
using ProdutoAPI.Domain.Interfaces.Repositories;
using ProdutoAPI.Domain.Interfaces.Service;
using ProdutoAPI.Domain.Services;
using ProdutoAPI.Infra.Data.SqlServer.Repositories;
using ProdutosAPI.Application.Interfaces.Services;
using ProdutosAPI.Application.Interfaces.Stores;
using ProdutosAPI.Application.Services;
using ProdutosAPI.Infra.Data.MongoDB.Stores;
    
namespace ProdutoAPI.Infra.IoC.Extensions
{
    public static class DependencyInjector
    {
        public static IServiceCollection AddDependecyInjector(this IServiceCollection services)
        {
            services.AddTransient<IProdutoAppService, ProdutoAppService>();
            services.AddTransient<IProdutoDomainService, ProdutoDomainService>();
            services.AddTransient<IProdutosStore, ProdutosStore>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
