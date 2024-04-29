using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProdutosAPI.Application.Interfaces.Services;
using ProdutosAPI.Application.Models.Commands;
using ProdutosAPI.Application.Models.Queries;

namespace ProdutoAPI.Service.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoAppService _produtoAppService;

    public ProdutosController(IProdutoAppService produtoAppService)
    {
        _produtoAppService = produtoAppService;
    }

    [HttpPost]
    [ProducesResponseType(typeof(ProdutosDTO), 201)]
    public async Task<IActionResult> Create(ProdutosCreateCommand command)
    {
        var response = await _produtoAppService.Create(command);
        return StatusCode(201, response);
    }

    [HttpPut]
    [ProducesResponseType(typeof(ProdutosDTO), 200)]
    public async Task<IActionResult> Update(ProdutosUpdateCommand command)
    {
        var response = await _produtoAppService.Update(command);
        return StatusCode(200, response);
    }

    [HttpGet]
    [ProducesResponseType(typeof(ProdutosDTO), 200)]
    public async Task<IActionResult> Get()
    {
        var response = _produtoAppService.GetAll();
        return StatusCode(200, response);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(typeof(ProdutosDTO), 200)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var produtoDeleteCommand = new ProdutosDeleteCommand()
        {
            Id = id,
        };

        var response = await _produtoAppService.Delete(produtoDeleteCommand);
        return StatusCode(200, response);
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteAll()
    {
        var produtos = _produtoAppService.GetAll();
        foreach (var produto in produtos.ToList())
        {
            await _produtoAppService.Delete(new ProdutosDeleteCommand{Id = produto.id});
        }

        return Ok();
    }

    [HttpGet("{id}")]
    [ProducesResponseType(typeof(ProdutosDTO), 200)]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = _produtoAppService.GetById(id);
        return StatusCode(200, response);
    }
    
}