using System.Net;
using Bogus;
using FluentAssertions;
using ProdutosAPI.Application.Models.Commands;
using ProdutosAPI.Application.Models.Queries;
using ProdutosAPI.Test.Helpers;
namespace ProdutosAPI.Test;

public class ProdutosTest
{
    private readonly string? _endpoint;
    private readonly Faker? _faker;

    public ProdutosTest()
    {
        _endpoint = "/api/produtos";
        _faker = new Faker("pt_BR");
    }

    [Fact]
    public async Task<ProdutosDTO> Test_Produtos_Post_Return_Create()
    {
        var command = new ProdutosCreateCommand()
        {
            Nome = _faker.Commerce.ProductName(),
            Preco = decimal.Parse(_faker.Commerce.Price(2)),
            Quantidade = _faker.Random.Number(0,100),
        };

        //criando um objeto HTTP Client para executar chamadas para a API
        var client = TestHelper.CreateClient;

        //executando a chamada para o serviço da API, enviando o command e capturando a resposta
        var result = await client.PostAsync(_endpoint ,TestHelper.CreateContent(command));
        
        //verificando se a resposta é 201 (CREATED)
        result.StatusCode.Should().Be(HttpStatusCode.Created);
        
        //deserializar os dados retornados pela api
        return TestHelper.ReadResponse<ProdutosDTO>(result);
    }
    [Fact(Skip = "")]
    public void Test_Produtos_Put_Return_Create()
    {
    }
    [Fact(Skip = "")]
    public void Test_Produtos_Delete_Return_Create()
    {
        
    }
    [Fact(Skip = "")]
    public void Test_Produtos_GetAll_Return_Create()
    {
        
    }
    [Fact(Skip = "")]
    public void Test_Produtos_Get_Return_Create()
    {
        
    }
}