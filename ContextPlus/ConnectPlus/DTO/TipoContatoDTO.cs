using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class TipoContatoDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O Titulo e obrigatorio!")]
    public string? Titulo { get; set; }
}
