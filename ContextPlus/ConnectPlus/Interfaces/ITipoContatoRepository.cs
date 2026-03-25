using ConnectPlus.Models;

namespace ConnectPlus.Interfaces;

public interface ITipoContatoRepository
{
    void cadastrar(TipoContato tipoContato);
    List<TipoContato> listar();
    TipoContato BuscarPorId(Guid id);
    void atualizar(Guid id, TipoContato tipoContato);
    void deletar(Guid id);
}
