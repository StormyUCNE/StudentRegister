using System.ComponentModel.DataAnnotations;
namespace StudentRegister.Models;
public class Asignaturas
{
    [Key]
    public int AsignaturaID { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, int.MaxValue, ErrorMessage = "No Se Aceptan Números Negativos")]
    public int Codigo { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string Aula { get; set; } = string.Empty;

    [Required(ErrorMessage = "Campo Obligatorio")]
    [Range(1, 4, ErrorMessage = "Valor de Crédito No Válido, Solo se acepta un rango de (1-4)")]
    public int Credito { get; set; }
}