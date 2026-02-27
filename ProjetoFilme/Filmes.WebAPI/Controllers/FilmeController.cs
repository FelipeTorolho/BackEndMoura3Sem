using Filmes.WebAPI.Interfaces;
using Filmes.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FilmeController : ControllerBase
{
    private readonly IFilmeRepository _filmeRepository;
    public FilmeController(IFilmeRepository filmeRepository)
    {
        _filmeRepository = filmeRepository;
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        try
        {
            return Ok(_filmeRepository.BuscarPorId(id));
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(_filmeRepository.Listar());
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPost]
    public IActionResult Post(Filme novoFilme)
    {
        try
        {
            _filmeRepository.Cadastrar(novoFilme);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut("{Id}")]
    public IActionResult Put(Guid Id, Filme filmeAtualizado)
    {
        try
        {
            _filmeRepository.AtualizarIdUrl(Id, filmeAtualizado);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }

    [HttpPut]
    public IActionResult PutBody(Filme filmeAtualizado)
    {
        try
        {
            _filmeRepository.AtualizarIdCorpo(filmeAtualizado);
            return NoContent();
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }

    }

     [HttpDelete("{id}")]
     public IActionResult Delete(Guid id)
     {
         try
         {
             _filmeRepository.Deletar(id);
             return NoContent();
         }
         catch (Exception erro)
         {
             return BadRequest(erro.Message);
         }
    }
}
