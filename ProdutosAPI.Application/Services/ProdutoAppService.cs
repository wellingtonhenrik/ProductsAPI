using MediatR;
using ProdutosAPI.Application.Interfaces.Services;
using ProdutosAPI.Application.Interfaces.Stores;
using ProdutosAPI.Application.Models.Commands;
using ProdutosAPI.Application.Models.Queries;

namespace ProdutosAPI.Application.Services;

/// <summary>
/// Implementação dos serviços da aplicação
/// </summary>
public class ProdutoAppService : IProdutoAppService
{
    private readonly IMediator _mediator;
    private readonly IProdutosStore _produtosStore;

    public ProdutoAppService(IMediator mediator, IProdutosStore produtosStore)
    {
        _mediator = mediator;
        _produtosStore = produtosStore;
    }

    public async Task<ProdutosDTO> Create(ProdutosCreateCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<ProdutosDTO> Update(ProdutosUpdateCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<ProdutosDTO> Delete(ProdutosDeleteCommand command)
    {
        return await _mediator.Send(command);
    }

    public List<ProdutosDTO> GetAll()
    {
        return _produtosStore.GetAll();
    }

    public ProdutosDTO GetById(Guid id)
    {
        return _produtosStore.GetById(id);
    }
}