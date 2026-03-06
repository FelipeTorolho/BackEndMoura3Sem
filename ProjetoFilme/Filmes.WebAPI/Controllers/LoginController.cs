using Filmes.WebAPI.DTO;
using Filmes.WebAPI.Interfaces;
using Filmes.WebAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Filmes.WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;
    public LoginController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpPost]
    public IActionResult Login(LoginDTO loginDto)
    {
        try
        {
            Usuario usuarioBuscado = _usuarioRepository.BuscarPorEmailESenha(loginDto.Email!, loginDto.Senha!);
            if (usuarioBuscado == null)
            {
                return NotFound("Email ou senha inválidos.");
            }

            var claims = new[]
            {
              // definir os dados que serão fornecidos no token - informações 
               new Claim(JwtRegisteredClaimNames.Jti,usuarioBuscado.IdUsuario),
               new Claim(JwtRegisteredClaimNames.Email,usuarioBuscado.Email!)

            };

            //2 - Define a chave de acesso do token
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("filmes-chave-autenticacao-webapi-dev"));

            //3 - Define as credenciais do token - (Header)
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //4 - Gerar o token
            var token = new JwtSecurityToken
            (
                // emissor do token
                issuer: "api_filmes", 

                // destinatário do token
                audience: "api_filmes",

                // dados definidos nas claims (informações)
                claims: claims,

                // tempo de expiração do token
                expires: DateTime.Now.AddMinutes(5), 

                // credenciais do token
                signingCredentials: creds 
            );

            //5 - Retorna o token criado
            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
        catch (Exception erro)
        {
            return BadRequest(erro.Message);
        }
    }
}
