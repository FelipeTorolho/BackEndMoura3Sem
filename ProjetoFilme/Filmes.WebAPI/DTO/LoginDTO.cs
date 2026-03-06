using System.ComponentModel.DataAnnotations;

namespace Filmes.WebAPI.DTO;

public class LoginDTO
{
    [Required(ErrorMessage = "O Email do usuario e obrigatorio!")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "A Senha do usuario e obrigatoria!")]
    public string? Senha { get; set; }       
}
