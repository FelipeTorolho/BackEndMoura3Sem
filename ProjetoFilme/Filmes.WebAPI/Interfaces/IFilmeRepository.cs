using Filmes.WebAPI.Models;

namespace Filmes.WebAPI.Interfaces;

public interface IFilmeRepository
{
        void Cadastrar(Filme novoFilme);
        List<Filme> Listar();
        void AtualizarCorpo(Filme filmeAtualizado);
        void AtualizarIdUrl(Guid id, Filme filmeAtualizado);
        void Deletar(Guid id);
        Filme BuscarPorId(Guid id);

}
