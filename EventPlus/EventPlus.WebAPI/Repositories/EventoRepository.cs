using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;

public class EventoRepository : IEventoRepository
{
    private readonly EventContext _context;
    public EventoRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Método para atualizar um evento existente, buscando o evento pelo id
    /// </summary>
    /// <param name="id">Id do evento a ser atualizado</param>
    /// <param name="evento">Objeto com as novas informações do evento</param>
    public void Atualizar(Guid id, Evento evento)
    {
        var eventoExistente = _context.Eventos.Find(id);
        if (eventoExistente != null)
        {
            eventoExistente.Nome = evento.Nome;
            eventoExistente.Descricao = evento.Descricao;
            eventoExistente.DataEvento = evento.DataEvento;
            eventoExistente.IdTipoEvento = evento.IdTipoEvento;
            eventoExistente.IdInstituicao = evento.IdInstituicao;
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Método para buscar um evento por seu id, incluindo as informações de tipo de evento e instituição relacionadas
    /// </summary>
    /// <param name="Id">Id do evento a ser buscado</param>
    /// <returns>retorna o evento encontrado</returns>
    public Evento BuscarPorId(Guid Id)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .FirstOrDefault(e => e.IdEvento == Id)!;
    }

    /// <summary>
    /// Método para cadastrar um novo evento, adicionando o evento ao contexto e salvando as alterações no banco de dados
    /// </summary>
    /// <param name="evento">Objeto com as informações do evento a ser cadastrado</param>
    public void Cadastrar(Evento evento)
    {
        _context.Eventos.Add(evento);
        _context.SaveChanges();
    }

    /// <summary>
    /// Método para deletar um evento existente, buscando o evento pelo id 
    /// </summary>
    /// <param name="id">Id do evento a ser deletado</param>
    public void Deletar(Guid id)
    {
        var eventoExistente = _context.Eventos.Find(id);
        if (eventoExistente != null)
        {
            _context.Eventos.Remove(eventoExistente);
            _context.SaveChanges();
        }
    }

    /// <summary>
    /// Método para listar todos os eventos
    /// </summary>
    /// <returns>Lista de eventos</returns>
    public List<Evento> Listar()
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .ToList();
    }

    /// <summary>
    /// Método que lista eventos filtrando pelas presencas de um usuário
    /// </summary>
    /// <param name="IdUsuario">Id do usuário para filtragem</param>
    /// <returns>Lista de eventos filtrados po usuário</returns>
    public List<Evento> ListarPorId(Guid IdUsuario)
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.Presencas.Any(p => p.IdUsuario == IdUsuario && p.Situacao == true))
            .ToList();
    }

    /// <summary>
    /// Método que retorna próximos eventos que irão acontecer
    /// </summary>
    /// <returns>Lista de próximos eventos</returns>
    public List<Evento> ListarProximos()
    {
        return _context.Eventos
            .Include(e => e.IdTipoEventoNavigation)
            .Include(e => e.IdInstituicaoNavigation)
            .Where(e => e.DataEvento >= DateTime.Now)
            .OrderBy(e => e.DataEvento)
            .ToList();
    }
}
