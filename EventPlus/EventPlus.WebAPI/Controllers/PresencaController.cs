using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PresencaController : ControllerBase
{
    private readonly IPresencaRepository _presencaRepository;
    public PresencaController(IPresencaRepository presencaRepository)
    {
        _presencaRepository = presencaRepository;
    }

    /// <summary>
    /// Endpoint da API que retorna uma lista de todas as presenças cadastradas
    /// </summary>
    /// <returns>Status code 200 e uma lista de presenças</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_presencaRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que retorna uma presença específica com base no id fornecido
    /// </summary>
    /// <param name="id">Id da presença</param>
    /// <returns>Status code 200 e a presença encontrada</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_presencaRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que retorna uma lista de presenças de um usuário específico
    /// </summary>
    /// <param name="idUsuario">id do usuário para filtragem</param>
    /// <returns>Status code 200 e uma lista de presenças</returns>
    [HttpGet("ListarMinhas/{idUsuario}")]
    public IActionResult BuscarMinhas(Guid idUsuario)
    {
        try
        {
            return Ok(_presencaRepository.ListarMinhas(idUsuario));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API para inscrever um usuário em um evento, criando uma nova presença
    /// </summary>
    /// <param name="presenca">Presença a ser criada</param>
    /// <returns>Status code 201</returns>
    [HttpPost]
    public IActionResult Inscrever(PresencaDTO presenca)
    {
        try
        {
            var novaPresenca = new Presenca
            {
                Situacao = presenca.Situacao,
                IdUsuario = presenca.IdUsuario,
                IdEvento = presenca.IdEvento
            };

            _presencaRepository.Inscrever(novaPresenca);
            return StatusCode(201, novaPresenca);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API para atualizar a situação de uma presença
    /// </summary>
    /// <param name="id">Id da presença a ser atualizada</param>
    /// <param name="presenca">Presença com os novos dados</param>
    /// <returns></returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, PresencaDTO presenca)
    {
        try
        {
            var presencaAtualizada = new Presenca
            {
                Situacao = presenca.Situacao,
                IdUsuario = presenca.IdUsuario,
                IdEvento = presenca.IdEvento
            };
            _presencaRepository.Atualizar(id);
            return StatusCode(204, presencaAtualizada);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API para remover uma presença, ou seja, cancelar a inscrição de um usuário em um evento
    /// </summary>
    /// <param name="id">Id da presença a ser removida</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Remover(Guid id)
    {
        try
        {
            _presencaRepository.Deletar(id);
            return StatusCode(204);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
