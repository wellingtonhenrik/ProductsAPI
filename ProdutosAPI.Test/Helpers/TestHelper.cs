using System.Text;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;

namespace ProdutosAPI.Test.Helpers;

public static class TestHelper
{
    //metodo para criar um client da api de produto
    public static HttpClient CreateClient => new WebApplicationFactory<Program>().CreateClient();
    
    //metodo para serializar o conteudo da requisição que sera enviada para um serviço
    public static StringContent CreateContent<TResquest>(TResquest request) =>
        new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

    //metodo para deserializar o retorno obtido pela execução do serviço
    public static TResponse ReadResponse<TResponse>(HttpResponseMessage message) =>
        JsonConvert.DeserializeObject<TResponse>(message.Content.ReadAsStringAsync().Result);
}