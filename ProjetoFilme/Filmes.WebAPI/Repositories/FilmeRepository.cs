using Filmes.WebAPI.BdContextFilme;
using Filmes.WebAPI.Interfaces;
using Filmes.WebAPI.Models;

namespace FilmesMoura.WebAPI.Repository
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly FilmeContext _context;

        public FilmeRepository(FilmeContext context)
        {
            _context = context;
        }

      

        public void AtualizarIdCorpo(Filme filmeAtualizado)
        {
            Filme filmeBuscado = _context.Filmes.Find(filmeAtualizado.IdFilme)!;

            try
            {
                if (filmeBuscado != null)
                {
                    filmeBuscado.Titulo = filmeAtualizado.Titulo;
                    filmeBuscado.IdGenero = filmeAtualizado.IdGenero;
                }

                _context.Filmes.Update(filmeBuscado!);
                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void AtualizarIdUrl(Guid id, Filme filme)
        {
            try
            {
               Filme filmeBuscado = _context.Filmes.Find(id.ToString())!;

                if (filmeBuscado != null)
                {
                    filmeBuscado.Titulo = filme.Titulo;
                    filmeBuscado.IdGenero = filme.IdGenero;
                }

              _context.Filmes.Update(filmeBuscado!);
              _context.SaveChanges();
            }

            catch (Exception)
            {
                throw;
            }
        }

        public Filme BuscarPorId(Guid id)
        {
            try
            {
                Filme filmeBuscado = _context.Filmes.Find(id.ToString())!;
                return filmeBuscado;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Filme novoFilme)
        {
            try
            {
                novoFilme.IdFilme = Guid.NewGuid().ToString();

                _context.Filmes.Add(novoFilme);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
               Filme filmeBuscado = _context.Filmes.Find(id.ToString())!;
                if (filmeBuscado != null)
                {
                    _context.Filmes.Remove(filmeBuscado);
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Filme> Listar()
        {
            try
            {
                List<Filme> listafilmes = _context.Filmes.ToList();

                return listafilmes;
            }
            catch (Exception e)
            {
                throw;
            }
        }

      
    }
}