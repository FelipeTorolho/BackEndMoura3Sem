using ConnectPlus.DTO;
using ConnectPlus.Models;
using ConnectPlus.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConnectPlus.Interfaces;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TipoContatoController : ControllerBase
{
    private readonly ITipoContatoRepository _tipoContatoRepository;

    public TipoContatoController(ITipoContatoRepository tipoContatoRepository)
    {
        _tipoContatoRepository = tipoContatoRepository;
    }

    /// <summary>
    /// Endpoint para cadastrar um novo tipo de contato
    /// </summary>
    /// <param name="tipoContato">Tipo de contato a ser cadastrado</param>
    /// <returns>Status code 201</returns>
    [HttpPost]
    public IActionResult Cadastrar(TipoContatoDTO tipoContato)
    {
        try
        {
            var novoTipoContato = new TipoContato
            {
                Titulo = tipoContato.Titulo!
            };
            _tipoContatoRepository.cadastrar(novoTipoContato);

            return StatusCode(201, novoTipoContato);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// EndPoint para listar todos os tipos de contato cadastrados no banco de dados
    /// </summary>
    /// <returns>Status code 200</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            var tipoContatos = _tipoContatoRepository.listar();
            return Ok(tipoContatos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint para buscar um tipo de contato por seu ID no banco de dados
    /// </summary>
    /// <param name="id">Id do tipo de contato a ser buscado</param>
    /// <returns>Status code 200</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_tipoContatoRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint para atualizar um tipo de contato já cadastrado no banco de dados, buscando-o por seu ID
    /// </summary>
    /// <param name="id">Id do tipo de contato a ser atualizado</param>
    /// <param name="tipoContato">Objeto com as novas informações do tipo de contato</param>
    /// <returns>Status code 204</returns>
    [HttpPut("{id}")]
    public IActionResult Atualizar(Guid id, TipoContatoDTO tipoContato)
    {
        try
        {
            var tipoContatoAtualizado = new TipoContato
            {
                Titulo = tipoContato.Titulo!
            };
            _tipoContatoRepository.atualizar(id, tipoContatoAtualizado);
            
            return StatusCode(204, tipoContatoAtualizado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint para deletar um tipo de contato do banco de dados, buscando-o por seu ID
    /// </summary>
    /// <param name="id">Id do tipo de contato a ser deletado</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _tipoContatoRepository.deletar(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}