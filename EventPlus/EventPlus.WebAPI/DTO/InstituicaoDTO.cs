using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO;

public class InstituicaoDTO
{
    [Required(ErrorMessage = "O nome não foi aceito")]
    public string? NomeFantasia { get; set; }
    [Required(ErrorMessage = "Endereço não reconhecido")]
    public string? Endereco { get; set; }
    [Required(ErrorMessage = "Cnpj não reconhecido")]
    public string? Cnpj { get; set; }
}
