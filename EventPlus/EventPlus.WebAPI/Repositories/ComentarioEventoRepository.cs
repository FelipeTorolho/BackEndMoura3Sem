using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories;

public class ComentarioEventoRepository : IComentarioEventoRepository
{
    private readonly EventContext _context;

    public ComentarioEventoRepository(EventContext context)
    {
        _context = context;
    }

    public void Cadastrar(ComentarioEvento comentarioEvento)
    {
        _context.ComentarioEventos.Add(comentarioEvento);
        _context.SaveChanges();
    }

    public ComentarioEvento BuscarPorId(Guid IdUsuario, Guid IdEvento)
    {
        return _context.ComentarioEventos
            .FirstOrDefault(c => c.IdUsuario == IdUsuario && c.IdEvento == IdEvento)!;
    }

    public void Deletar(Guid idComentarioEvento)
    {
        var comentarioBuscado = _context.ComentarioEventos.Find(idComentarioEvento);

        if (comentarioBuscado != null)
        {
            _context.ComentarioEventos.Remove(comentarioBuscado);
            _context.SaveChanges();
        }
    }

    public List<ComentarioEvento> List(Guid IdEvento)
    {
        return _context.ComentarioEventos
            .Where(c => c.IdEvento == IdEvento)
            .ToList();
    }
 
    public List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento)
    {
        return _context.ComentarioEventos
            .Where(c => c.IdEvento == IdEvento && c.Exibe)
            .ToList();
    }
}