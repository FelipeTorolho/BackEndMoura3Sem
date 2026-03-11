using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;

namespace EventPlus.WebAPI.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        private readonly EventContext _context;
        public InstituicaoRepository(EventContext context)
        {
            _context = context;
        }

        public void Atualizar(Guid id, Instituicao instituicao)
        {
           var instituicaoExistente = _context.Instituicaos.Find(id);
            if (instituicaoExistente != null)
            {
                 instituicaoExistente.NomeFantasia = instituicao.NomeFantasia;
                 instituicaoExistente.Endereco = instituicao.Endereco;
                 instituicaoExistente.Cnpj = instituicao.Cnpj;
                 _context.SaveChanges();
            }
        }

        public Instituicao BuscarPorId(Guid Id)
        {
           return _context.Instituicaos.Find(Id)!;
        }

        public void Cadastrar(Instituicao instituicao)
        {
            _context.Instituicaos.Add(instituicao);
            _context.SaveChanges();
        }

        public void Deletar(Guid id)
        {
            var instituicaoExistente = _context.Instituicaos.Find(id);
            if (instituicaoExistente != null)
            {
                _context.Instituicaos.Remove(instituicaoExistente);
                _context.SaveChanges();
            }
        }

        public List<Instituicao> Listar()
        {
            return _context.Instituicaos
                .OrderBy(instituicao => instituicao.NomeFantasia)
                .ToList();
        }
    }
}
