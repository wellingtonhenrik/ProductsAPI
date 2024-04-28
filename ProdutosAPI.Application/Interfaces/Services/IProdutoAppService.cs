using ProdutosAPI.Application.Models.Commands;
using ProdutosAPI.Application.Models.Queries;

namespace ProdutosAPI.Application.Interfaces.Services;

/// <summary>
/// Interfa para os serviços da aplicação
/// </summary>
public interface IProdutoAppService
{
    Task<ProdutosDTO> Create(ProdutosCreateCommand command);
    Task<ProdutosDTO> Update(ProdutosUpdateCommand command);
    Task<ProdutosDTO> Delete(ProdutosDeleteCommand command);

    List<ProdutosDTO> GetAll();
    ProdutosDTO GetById(Guid id);

}