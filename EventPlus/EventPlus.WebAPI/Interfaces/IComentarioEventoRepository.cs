using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Interfaces;

public interface IComentarioEventoRepository
{
    void Cadastrar(CometarioEvento comentarioEvento);
    void Deletar(Guid idComentarioEvento);
    List<CometarioEvento> List(Guid IdEvento);
    CometarioEvento BuscarPorId(Guid IdUsuario, Guid IdEvento);
    List<CometarioEvento> ListarSomenteExibe(Guid IdEvento);
}
