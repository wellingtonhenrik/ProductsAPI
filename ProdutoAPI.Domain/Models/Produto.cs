namespace ProdutoAPI.Domain.Models;

public class Produto
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public decimal? Preco { get; set; }
    public int? Quantidade { get; set; }
    public DateTime? DataCriacao { get; set; }
    public DateTime? DataUltimaAlteracao { get; set; }
}