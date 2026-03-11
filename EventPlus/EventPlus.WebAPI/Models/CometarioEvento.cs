using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace EventPlus.WebAPI.Models;

[Table("CometarioEvento")]
public partial class CometarioEvento
{
    [Key]
    public Guid IdComentarioEvento { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime DataComentarioEvento { get; set; }

    [StringLength(100)]
    public string Nome { get; set; } = null!;

    [StringLength(200)]
    public string Descricao { get; set; } = null!;

    public bool Exibe { get; set; }

    public Guid? IdUsuario { get; set; }

    public Guid? IdEvento { get; set; }

    [ForeignKey("IdEvento")]
    [InverseProperty("CometarioEventos")]
    public virtual Evento? IdEventoNavigation { get; set; }

    [ForeignKey("IdUsuario")]
    [InverseProperty("CometarioEventos")]
    public virtual Usuario? IdUsuarioNavigation { get; set; }
}
