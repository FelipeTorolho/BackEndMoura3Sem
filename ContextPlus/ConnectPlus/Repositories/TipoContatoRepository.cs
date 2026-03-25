using ConnectPlus.BdContextConnect;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;

namespace ConnectPlus.Repositories;

public class TipoContatoRepository : ITipoContatoRepository
{
    private readonly ConnectContext _context;

    public TipoContatoRepository(ConnectContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Metodo que atualiza um tipo de contato existente no banco de dados.
    /// </summary>
    /// <param name="id">Id do tipo de contato a ser atualizado.</param>
    /// <param name="tipoContato">Objeto com as novas informações do tipo de contato.</param>
    public void atualizar(Guid id, TipoContato tipoContato)
    {
        var tipoContatoExistente = _context.TipoContatos.Find(id);
        if (tipoContatoExistente != null)
        {
            tipoContatoExistente.Titulo = tipoContato.Titulo;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo que busca um tipo de contato por seu ID no banco de dados.
    /// </summary>
    /// <param name="id">Id do tipo de contato a ser buscado.</param>
    /// <returns>Retorna o tipo de contato encontrado</returns>
    public TipoContato BuscarPorId(Guid id)
    {
        return _context.TipoContatos.Find(id)!;
    }

    /// <summary>
    /// Metodo que cadastra um novo tipo de contato no banco de dados.
    /// </summary>
    /// <param name="tipoContato">Tipo de contato a ser cadastrado.</param>
    public void cadastrar(TipoContato tipoContato)
    {
        _context.TipoContatos.Add(tipoContato);
        _context.SaveChanges();
    }

    /// <summary>
    /// Metodo que deleta um tipo de contato do banco de dados, caso ele exista.
    /// </summary>
    /// <param name="id">Id do tipo de contato a ser deletado.</param>
    public void deletar(Guid id)
    {
        var tipoContato = _context.TipoContatos.Find(id);
        if (tipoContato != null)
        {
            _context.TipoContatos.Remove(tipoContato);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo que lista todos os tipos de contato cadastrados no banco de dados.
    /// </summary>
    /// <returns>Retorna uma lista de tipos de contato.</returns>
    public List<TipoContato> listar()
    {
        return _context.TipoContatos.ToList();
    }
}
