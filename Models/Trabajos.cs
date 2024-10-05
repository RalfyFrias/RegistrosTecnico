using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace RegistroTecnicos.Models;

public class Trabajos
{
    [Key]
    public int TrabajoId { get; set; }

    [Required(ErrorMessage = "Favor colocar una Fecha")]
    public DateTime Fecha { get; set; }

    [Required(ErrorMessage = "Favor colocar un Cliente")]
    [ForeignKey("Clientes")]
    public int? ClienteId { get; set; }
    public Clientes? Clientes { get; set; }

    [Required(ErrorMessage = "Favor Seleccionar un Técnico")]
    [ForeignKey("Tecnicos")]
    public int? TecnicoId { get; set; }
    public Tecnicos? Tecnicos { get; set; }

    [Required(ErrorMessage = "Favor Seleccionar una Descripción")]

    public string? Descripcion { get; set; }

    [Required(ErrorMessage = "Favor Colocar un Monto")]

    public decimal? Monto { get; set; }

    [Required(ErrorMessage = "Favor seleccionar una Prioridad")]
    [ForeignKey("Prioridades")]
    public int? PrioridadId { get; set; }
    public Prioridades? Prioridades { get; set; }


}



