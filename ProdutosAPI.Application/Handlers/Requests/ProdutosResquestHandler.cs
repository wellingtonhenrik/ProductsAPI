using System.Diagnostics;
using MediatR;
using ProdutoAPI.Domain.Interfaces.Service;
using ProdutoAPI.Domain.Models;
using ProdutosAPI.Application.Handlers.Notifications;
using ProdutosAPI.Application.Models.Commands;
using ProdutosAPI.Application.Models.Queries;

namespace ProdutosAPI.Application.Handlers.Requests;

/// <summary>
/// Componente para 'escutar' as requisições do tipo COMMAND de produtos
/// </summary>
public class ProdutosResquestHandler :
    IRequestHandler<ProdutosCreateCommand, ProdutosDTO>,
    IRequestHandler<ProdutosUpdateCommand, ProdutosDTO>,
    IRequestHandler<ProdutosDeleteCommand, ProdutosDTO>
{
    private readonly IMediator? _mediator;
    private readonly IProdutoDomainService _produtoDomainService;

    public ProdutosResquestHandler(IMediator? mediator, IProdutoDomainService produtoDomainService)
    {
        _mediator = mediator;
        _produtoDomainService = produtoDomainService;
    }

    /// <summary>
    /// Metodo para processar o COMMAND CREATE do produto
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ProdutosDTO> Handle(ProdutosCreateCommand request, CancellationToken cancellationToken)
    {
        var produto = new Produto
        {
            DataCriacao = DateTime.UtcNow,
            Id = Guid.NewGuid(),
            Nome = request.Nome,
            Preco = request.Preco,
            Quantidade = request.Quantidade,
        };

        _produtoDomainService.Add(produto);

        var dto = new ProdutosDTO()
        {
            Nome = produto.Nome,
            Preco = produto.Preco,
            Quantidade = produto.Quantidade,
            DataCriacao = produto.DataCriacao,
            id = produto.Id,
        };

        // envia uma notificação para que o DTO seja enviado 
        // em um banco de dados para leitura
        await _mediator.Publish(new ProdutosNotification()
        {
            Action = ActionNotification.Created,
            ProdutosDTO = dto,
        });

        return dto;
    }


    /// <summary>
    /// Metodo para processar o COMMAND UPDATE do produto
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ProdutosDTO> Handle(ProdutosUpdateCommand request, CancellationToken cancellationToken)
    {
        var produto = _produtoDomainService.GetById(request.Id);
        if (produto == null) return new ProdutosDTO();
        produto.Quantidade = request.Quantidade;
        produto.Preco = request.Preco;
        produto.DataUltimaAlteracao = DateTime.UtcNow;
        produto.Nome = request.Nome;

        _produtoDomainService.Update(produto);

        var dto = new ProdutosDTO()
        {
            Nome = produto.Nome,
            Preco = produto.Preco,
            Quantidade = produto.Quantidade,
            id = produto.Id,
            DataUltimaAlteracao = produto.DataCriacao,
        };

        // envia uma notificação para que o DTO seja enviado 
        // em um banco de dados para leitura
        await _mediator.Publish(new ProdutosNotification()
        {
            Action = ActionNotification.Update,
            ProdutosDTO = dto,
        });

        return dto;
    }


    /// <summary>
    /// Metodo para processar o COMMAND DELETE do produto
    /// </summary>
    /// <param name="request"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<ProdutosDTO> Handle(ProdutosDeleteCommand request, CancellationToken cancellationToken)
    {
        var produto = _produtoDomainService.GetById(request.Id);
        if (produto == null) return new ProdutosDTO();

        _produtoDomainService.Delete(produto);

        var dto = new ProdutosDTO()
        {
            id = produto.Id,
            DataCriacao = produto.DataCriacao,
            Nome = produto.Nome,
            Preco = produto.Preco,
            Quantidade = produto.Quantidade,
            DataUltimaAlteracao = produto.DataUltimaAlteracao
        };

        // envia uma notificação para que o DTO seja enviado 
        // em um banco de dados para leitura
        await _mediator.Publish(new ProdutosNotification()
        {
            Action = ActionNotification.Delete,
            ProdutosDTO = dto,
        });

        return dto;
    }
}