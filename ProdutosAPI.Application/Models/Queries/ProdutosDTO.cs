namespace ProdutosAPI.Application.Models.Queries;

public class ProdutosDTO
{
    public Guid id { get; set; }
    
    public string? Nome { get; set; }
    public int? Quantidade { get; set; }
    public decimal? Preco { get; set; }

    public decimal? ValorTotal
    {
        get => Preco * Quantidade;
    }

    public DateTime? DataCriacao { get; set; }
    
    public DateTime? DataUltimaAlteracao { get; set; }
}