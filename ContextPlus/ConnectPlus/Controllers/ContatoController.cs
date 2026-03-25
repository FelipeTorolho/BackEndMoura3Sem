using ConnectPlus.DTO;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;
using ConnectPlus.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConnectPlus.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ContatoController : ControllerBase
{
    private readonly IContatoRepository _contatoRepository;

    public ContatoController(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }

    /// <summary>
    /// Endpoint para cadastrar um novo contato.
    /// </summary>
    /// <param name="contato">Id do contato a ser cadastrado</param>
    /// <returns>Status code 201</returns>
    [HttpPost]
    public async Task<IActionResult> Cadastrar([FromForm] ContatoDTO contato)
    {
        try
        {
            var novoContato = new Contato
            {
                Nome = contato.Nome!,
                DadosContato = contato.DadosContato!,
                IdTipoContato = contato.TipoContatoId
            };

            // Lógica de salvar imagem extraída do seu exemplo
            if (contato.Imagem != null && contato.Imagem.Length > 0)
            {
                var extensao = Path.GetExtension(contato.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagem.CopyToAsync(stream);
                }

                novoContato.Imagem = nomeArquivo;
            }

            _contatoRepository.cadastrar(novoContato);
            return StatusCode(201);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint para listar todos os contatos cadastrados no banco de dados.
    /// </summary>
    /// <returns>Status Code 200</returns>
    [HttpGet]
    public IActionResult Listar()
    {
        try
        {
            var contatos = _contatoRepository.listar();
            return Ok(contatos);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint para buscar um contato por seu ID no banco de dados.
    /// </summary>
    /// <param name="id">Id do contato a ser buscado</param>
    /// <returns>Status code 200</returns>
    [HttpGet("{id}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            return Ok(_contatoRepository.BuscarPorId(id));
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint para atualizar um contato existente no banco de dados, utilizando o ID do contato e os dados atualizados.
    /// </summary>
    /// <param name="Id">Id do contato a ser atualizado</param>
    /// <param name="contato">Objeto com as novas informações do contato</param>
    /// <returns>Status code 204</returns>
    [HttpPut("{Id}")]
    public async Task<IActionResult> Atualizar(Guid Id, [FromForm] ContatoDTO contato)
    {
        try
        {
            var contatoBuscado = new Contato
            {
                Nome = contato.Nome!,
                DadosContato = contato.DadosContato!,
                IdTipoContato = contato.TipoContatoId
            };

            // Lógica de salvar imagem no Atualizar
            if (contato.Imagem != null && contato.Imagem.Length > 0)
            {
                var extensao = Path.GetExtension(contato.Imagem.FileName);
                var nomeArquivo = $"{Guid.NewGuid()}{extensao}";
                var pastaRelativa = "wwwroot/imagens";
                var caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), pastaRelativa);

                if (!Directory.Exists(caminhoPasta))
                    Directory.CreateDirectory(caminhoPasta);

                var caminhoCompleto = Path.Combine(caminhoPasta, nomeArquivo);

                using (var stream = new FileStream(caminhoCompleto, FileMode.Create))
                {
                    await contato.Imagem.CopyToAsync(stream);
                }

                contatoBuscado.Imagem = nomeArquivo;
            }

            _contatoRepository.atualizar(Id, contatoBuscado);
            return StatusCode(204, contatoBuscado);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    /// <summary>
    /// Endpoint para deletar um contato do banco de dados, utilizando o ID do contato a ser deletado.
    /// </summary>
    /// <param name="id">Id do contato a ser deletado</param>
    /// <returns>Status code 204</returns>
    [HttpDelete("{id}")]
    public IActionResult Deletar(Guid id)
    {
        try
        {
            _contatoRepository.deletar(id);

            return NoContent();
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
    }
}
