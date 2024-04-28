using ProdutoAPI.Domain.Interfaces.Repositories;
using ProdutoAPI.Domain.Interfaces.Service;
using ProdutoAPI.Domain.Models;

namespace ProdutoAPI.Domain.Services;

public class ProdutoDomainService : BaseDomainService<Produto,Guid>, IProdutoDomainService
{
    private readonly IUnitOfWork _unitOfWork;

    public ProdutoDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.ProdutoRepository)
    {
        _unitOfWork = unitOfWork;
    }
}