using ConnectPlus.Models;

namespace ConnectPlus.Interfaces;

public interface IContatoRepository
{
        void cadastrar(Contato contato);
        List<Contato> listar();
        Contato BuscarPorId(Guid id);
        void atualizar(Guid id, Contato contato);
        void deletar(Guid id);
}
