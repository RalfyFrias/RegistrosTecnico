using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RegistroTecnicos.Models;

public class Trabajos
{
    [Key]
    public int TrabajoId { get; set; }
    [Required(ErrorMessage = "Favor colocar una fecha")]
    public DateTime Fecha { get; set; }
    [Required (ErrorMessage ="Favor colocar un cliente")]
    [ForeignKey("Clientes")]
    public int ClienteId { get; set; }
    public Clientes? Clientes { get; set; }
    [Required(ErrorMessage = "Favor colocar un tecnico")]
    [ForeignKey("Tecnicos")]
    public int TecnicoId { get; set; }
    public Tecnicos? Tecnicos { get; set; }
    [Required(ErrorMessage = "Favor colocar una descripcion")]
    public string? Descripcion { get; set; }
    [Required(ErrorMessage = "Favor colocar un monto")]
    public decimal? Monto { get; set; }

}