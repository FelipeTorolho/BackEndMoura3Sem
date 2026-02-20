using Filmes.WebAPI.Interfaces;
using Filmes.WebAPI.Models;

namespace FilmesMoura.WebAPI.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        public void AtualizarCorpo(Filme filmeAtualizado)
        {
            throw new NotImplementedException();
        }

        public void AtualizarIdUrl(Guid id, Filme filme)
        {
            throw new NotImplementedException();
        }

        public Filme BuscarPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Filme NovoFilme)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Filme> Listar()
        {
            throw new NotImplementedException();
        }
    }
}