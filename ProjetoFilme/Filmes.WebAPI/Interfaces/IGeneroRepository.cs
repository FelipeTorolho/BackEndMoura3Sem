using Filmes.WebAPI.Models;

namespace Filmes.WebAPI.Interfaces;

public interface IGeneroRepository
{
    void Cadastrar(Genero novoGenero);
    List<Genero> Listar();
    void AtualizarIdUrl(Guid id, Genero generoAtualizado);
    void Deletar(Guid id);
    Genero BuscarPorId(Guid id);
    void AtualizarIdCorpo(Genero generoAtualizado);
}
