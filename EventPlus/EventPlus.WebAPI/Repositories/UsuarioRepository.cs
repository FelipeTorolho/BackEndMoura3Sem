using EventPlus.WebAPI.BdContextEvent;
using EventPlus.WebAPI.Interfaces;
using EventPlus.WebAPI.Models;
using EventPlus.WebAPI.Utils;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Repositories;


public class UsuarioRepository : IUsuarioRepository
 {
    private readonly EventContext _context;
    public UsuarioRepository(EventContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Busca um usuário pelo email e valida o hash da senha.
    /// </summary>
    /// <param name="email">email do usuário</param>
    /// <param name="Senha">senha do usuário</param>
    /// <returns>Usuário buscado e validado</returns>
    public Usuario BuscarPorEmailESenha(string email, string Senha)
    {
        //Primeiro, buscamos o usuário pelo email
        var usuarioBuscado = _context.Usuarios
            .Include(usuario => usuario.IdTipoUsuarioNavigation)
            .FirstOrDefault(usuario => usuario.Email == email);

        //Verifica se o usuário realmente existe
        if (usuarioBuscado != null)
        {
             //Comparamos o hash da senha digitada com o que está no banco de dados
             bool confere = Criptografia.CompararHash(Senha, usuarioBuscado.Senha);

             if (confere)
            {
                return usuarioBuscado;
            }
        }

        return null!;
    }

    /// <summary>
    /// Busca um usuário por seu ID, incluindo os dados do seu tipo usuário.
    /// </summary>
    /// <param name="IdUsuario">Id do usuário a ser buscado</param>
    /// <returns>Usuário buscado</returns>
    public Usuario BuscarPorId(Guid IdUsuario)
    {
        return _context.Usuarios
            .Include(usuario => usuario.IdTipoUsuarioNavigation)
            .FirstOrDefault(usuario => usuario.IdUsuario == IdUsuario)!;
    }

    /// <summary>
    /// Cadastra um novo usuário com a senha criptografada.
    /// </summary>
    /// <param name="usuario">Usuário a ser cadastrado</param>
    public void Cadastrar(Usuario usuario)
    {
        usuario.Senha = Criptografia.GerarHash(usuario.Senha);

        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }
}
