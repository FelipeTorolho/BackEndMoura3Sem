using ConnectPlus.BdContextConnect;
using ConnectPlus.Interfaces;
using ConnectPlus.Models;

namespace ConnectPlus.Repositories;

public class ContatoRepository : IContatoRepository
{
    private readonly ConnectContext _context;

    public ContatoRepository(ConnectContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Metodo que atualiza um contato no banco de dados, buscando o contato pelo seu Id e atualizando suas informações
    /// </summary>
    /// <param name="id">Id do contato a ser atualizado</param>
    /// <param name="contato">Objeto com as novas informações do contato</param>
    public void atualizar(Guid id, Contato contato)
    {
        var contatoExistente = _context.Contatos.Find(id);
        if (contatoExistente != null)
        {
            contatoExistente.Nome = contato.Nome;
            contatoExistente.DadosContato = contato.DadosContato;
            contatoExistente.Imagem = contato.Imagem;
            contatoExistente.IdTipoContato = contato.IdTipoContato;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo que busca um contato no banco de dados pelo seu Id
    /// </summary>
    /// <param name="id">Id do contato a ser buscado</param>
    /// <returns>Retorna o contato encontrado</returns>
    public Contato BuscarPorId(Guid id)
    {
        return _context.Contatos.Find(id)!;
    }

    /// <summary>
    /// Metodo que cadastra um contato no banco de dados
    /// </summary>
    /// <param name="contato">Contato a ser cadastrado</param>
    public void cadastrar(Contato contato)
    {
        _context.Contatos.Add(contato);
        _context.SaveChanges();
    }

    /// <summary>
    /// Metodo que deleta um contato do banco de dados
    /// </summary>
    /// <param name="id">Id do contato a ser deletado.</param>
    public void deletar(Guid id)
    {
        var contato = _context.Contatos.Find(id);
        if (contato != null)
        {
            _context.Contatos.Remove(contato);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Metodo que lista os contatos cadastrados no banco de dados
    /// </summary>
    /// <returns>Retorna a Lista dos contatos salvos</returns>
    public List<Contato> listar()
    {
        return _context.Contatos.ToList();
    }
}
