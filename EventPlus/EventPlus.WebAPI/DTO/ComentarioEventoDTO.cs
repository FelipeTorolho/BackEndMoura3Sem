using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class ComentarioEventoDTO
{
    [Required(ErrorMessage = "A descrição do comentario e obrigatoria!")]
    public string? Descricao { get; set; }
    public Guid IdUsuario { get; set; }
    public Guid IdEvento { get; set; }
}
