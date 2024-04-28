using MediatR;
using ProdutosAPI.Application.Models.Queries;

namespace ProdutosAPI.Application.Models.Commands;

public class ProdutosDeleteCommand : IRequest<ProdutosDTO>
{
    public Guid Id { get; set; }
}