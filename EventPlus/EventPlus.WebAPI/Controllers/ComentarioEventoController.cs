using Azure;
using Azure.AI.ContentSafety;
using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ComentarioEventoController : ControllerBase
{
    private readonly ContentSafetyClient _contentSafetyClient;
    private readonly IComentarioEventoRepository _comentarioEventoRepository;

    public ComentarioEventoController(ContentSafetyClient contentSafetyClient, IComentarioEventoRepository comentarioEventoRepository)
    {
        _contentSafetyClient = contentSafetyClient;
        _comentarioEventoRepository = comentarioEventoRepository;
    }

    [HttpPost]
    public async Task<IActionResult> Post(ComentarioEventoDTO comentarioEvento)
    {
       try
        {
            if (string.IsNullOrEmpty(comentarioEvento.Descricao))
            { 
                return BadRequest("A descrição do comentário não pode ser vazia.");
            }

            //Criar objeto de analise
            var request = new AnalyzeTextOptions(comentarioEvento.Descricao);

            //Chamar a API do azure content safety
            Response<AnalyzeTextResult> response = await _contentSafetyClient.AnalyzeTextAsync(request);

            //Verificar se o texto tem alguma coisa maior que zero
            bool temConteudoImpropio = response.Value.CategoriesAnalysis.Any(c => c.Severity > 0);

            var novoComenterio = new ComentarioEvento
            {
                IdEvento = comentarioEvento.IdEvento,
                IdUsuario = comentarioEvento.IdUsuario,
                Descricao = comentarioEvento.Descricao,
                Exibe = !temConteudoImpropio,
                DataComentarioEvento = DateTime.Now
            };

            _comentarioEventoRepository.Cadastrar(novoComenterio);
            return StatusCode(201, novoComenterio);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid idEvento, Guid idUsuario)
    {
        try
        {
            return Ok(_comentarioEventoRepository.BuscarPorId(idEvento, idUsuario));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet]
    public IActionResult Listar(Guid idEvento)
    {
        try
        {
            return Ok(_comentarioEventoRepository.List(idEvento));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpGet("ListarSomenteExibe/{id}")]
    public IActionResult ListarSomenteExibe(Guid id)
    {
        try
        {
            return Ok(_comentarioEventoRepository.ListarSomenteExibe(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpDelete]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _comentarioEventoRepository.Deletar(id);
            return StatusCode(204);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
