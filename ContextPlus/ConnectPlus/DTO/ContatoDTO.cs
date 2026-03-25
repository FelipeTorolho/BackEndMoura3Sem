using System.ComponentModel.DataAnnotations;

namespace ConnectPlus.DTO;

public class ContatoDTO
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O Nome e obrigatorio!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Os Dados de Contato e obrigatorio!")]
    public string? DadosContato { get; set; }

    [Required(ErrorMessage = "A Imagem e obrigatoria!")]
    public IFormFile? Imagem { get; set; }
    public Guid TipoContatoId { get; set; }
}
