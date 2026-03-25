using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IComentarioEventoRepository
{
    void Cadastrar(ComentarioEvento comentarioEvento);
    void Deletar(Guid idComentarioEvento);
    List<ComentarioEvento> List(Guid IdEvento);
    ComentarioEvento BuscarPorId(Guid IdUsuario, Guid IdEvento);
    List<ComentarioEvento> ListarSomenteExibe(Guid IdEvento);
}
