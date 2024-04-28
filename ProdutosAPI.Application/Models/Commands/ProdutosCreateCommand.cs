using System.ComponentModel.DataAnnotations;
using MediatR;
using ProdutosAPI.Application.Models.Queries;

namespace ProdutosAPI.Application.Models.Commands;

/// <summary>
/// Modelo de dados para o serviço de criação de produto
/// </summary>
public class ProdutosCreateCommand : IRequest<ProdutosDTO>
{
    
    [Required(ErrorMessage = "Informe nome do produto")]
    [MinLength(2,ErrorMessage = "Informe no minimo {1} caracteres")]
    [MaxLength(150, ErrorMessage = "Informe no maximo {1} caracteres")]
    public string? Nome { get; set; }
    
    [Required(ErrorMessage = "Informe preço do produto")]
    public decimal? Preco { get; set; }

    [Required(ErrorMessage = "Informe quantidade do produto")]
    public int Quantidade { get; set; }
}