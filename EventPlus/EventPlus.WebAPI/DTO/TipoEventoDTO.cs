using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class TipoEventoDTO
{
    [Required(ErrorMessage = "O titulo do tipo de evento e obrigatorio!")]
    public string? Titulo { get; set; }
}
