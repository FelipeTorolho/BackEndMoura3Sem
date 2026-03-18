using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class EventoDTO
{
    [Required(ErrorMessage = "O nome do evento e obrigatorio!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "A descricao do evento e obrigatoria!")]
    public string? Descricao { get; set; }

    public DateTime DataEvento { get; set; }

    public Guid IdTipoEvento { get; set; }

    public Guid IdInstituicao { get; set; }
}
