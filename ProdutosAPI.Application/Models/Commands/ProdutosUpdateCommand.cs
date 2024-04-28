using System.ComponentModel.DataAnnotations;
using MediatR;
using ProdutosAPI.Application.Models.Queries;

namespace ProdutosAPI.Application.Models.Commands;

public class ProdutosUpdateCommand : IRequest<ProdutosDTO>
{
    [Required(ErrorMessage = "Informe Id do produto")]
    public Guid Id { get; set; }
    
    [Required(ErrorMessage = "Informe nome do produto")]
    [MinLength(2,ErrorMessage = "Informe no minimo {1} caracteres")]
    [MaxLength(150, ErrorMessage = "Informe no maximo {1} caracteres")]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "Informe preço do produto")]
    public decimal? Preco { get; set; }

    [Required(ErrorMessage = "Informe quantidade do produto")]
    public int Quantidade { get; set; }
}