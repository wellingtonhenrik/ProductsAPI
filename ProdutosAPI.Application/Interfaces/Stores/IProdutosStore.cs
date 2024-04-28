using ProdutosAPI.Application.Models.Queries;

namespace ProdutosAPI.Application.Interfaces.Stores
{
    public interface IProdutosStore
    {
        void Add(ProdutosDTO item);
        void Update(ProdutosDTO item);
        void Delete(Guid id);
        List<ProdutosDTO> GetAll();
        ProdutosDTO GetById(Guid id);
    }
}
