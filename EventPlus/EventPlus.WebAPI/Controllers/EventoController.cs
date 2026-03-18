using EventPlus.WebAPI.DTO;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EventPlus.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventoController : ControllerBase
{
    private readonly IEventoRepository _eventoRepository;
    public EventoController(IEventoRepository eventoRepository)
    {
        _eventoRepository = eventoRepository;
    }

    /// <summary>
    /// Endpoint da API que faz chamadas para o método de cadastrar eventos
    /// </summary>
    /// <param name="evento">Evento a ser cadastrado</param>
    /// <returns>Status code 201</returns>
    [HttpPost]
    public IActionResult Cadastrar(EventoDTO evento)
    {
        try
        {
            var novoEvento = new Evento
            {
                Nome = evento.Nome!,
                Descricao = evento.Descricao!,
                DataEvento = evento.DataEvento!,
                IdTipoEvento = evento.IdTipoEvento!,
                IdInstituicao= evento.IdInstituicao!
            };
            _eventoRepository.Cadastrar(novoEvento);

            return StatusCode(201, novoEvento);
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamadas para o método de buscar um evento por um id
    /// </summary>
    /// <param name="id">Id do evento a ser buscado</param>
    /// <returns>Status code 200</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_eventoRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamadas para o método de listar os próximos eventos, ou seja, eventos com data futura
    /// </summary>
    /// <returns>Status code 200</returns>
    [HttpGet("ListarProximos")]
    public IActionResult BuscarProximos()
    {
        try
        {
            return Ok(_eventoRepository.ListarProximos());
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamadas para o método de listar eventos
    /// </summary>
    /// <returns>Status code 200</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            return Ok(_eventoRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamadas para o método de listar eventos filtrados por usuário
    /// </summary>
    /// <param name="idUsuario">Id do usuário para filtragem</param>
    /// <returns>Lista de eventos filtrados por usuário</returns>
    [HttpGet("Usuario/{idUsuario}")]
    public IActionResult ListarPorId(Guid idUsuario)
    {
        try
        {
            return Ok(_eventoRepository.ListarPorId(idUsuario));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    /// <summary>
    /// Endpoint da API que faz chamadas para o método de atualizar eventos
    /// </summary>
    /// <param name="id">Id do evento a ser atualizado</param>
    /// <param name="evento">Evento atualizado</param>
    /// <returns>Status code 204</returns>
    [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, EventoDTO evento)
        {
            try
            {
                var eventoAtualizado = new Evento
                {
                    Nome = evento.Nome!,
                    Descricao = evento.Descricao!,
                    DataEvento = evento.DataEvento!,
                    IdTipoEvento = evento.IdTipoEvento!,
                    IdInstituicao = evento.IdInstituicao!
                };
                _eventoRepository.Atualizar(id, eventoAtualizado);

                return StatusCode(204, eventoAtualizado);
            }
            catch (Exception erro)
            {
                return BadRequest(erro.Message);
            }
        }

    /// <summary>
    /// Endpoint da API que faz chamadas para o método de deletar eventos
    /// </summary>
    /// <param name="id">Id do evento a ser deletado</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
      public IActionResult Deletar(Guid id)
      {
        try
        {
            _eventoRepository.Deletar(id);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }

      }
}
