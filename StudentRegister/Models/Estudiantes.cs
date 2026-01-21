using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StudentRegister.Models;
public class Estudiantes
{
    [Key]
    public int EstudianteId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string Nombres { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    [EmailAddress(ErrorMessage = "Email no válido")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, 110, ErrorMessage = "Edad Debe ser Entre 1 a 110 años")]
    public int Edad { get; set; }
}