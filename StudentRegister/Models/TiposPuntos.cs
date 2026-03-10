using System.ComponentModel.DataAnnotations;
namespace StudentRegister.Models;
public class TiposPuntos
{
    [Key]
    public int TipoId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string Descricion { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, 100, ErrorMessage = "Puntos Solo deben de ser entre 1 - 100")]
    public int ValorPuntos { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string Color { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string Icono { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    public bool Activo { get; set; }
}