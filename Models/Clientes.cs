using System.ComponentModel.DataAnnotations;
namespace RegistroTecnicos.Models;

public class Clientes
{
    [Key]
    public int ClienteId { get; set; }
    [Required (ErrorMessage ="Favor colocar su nombre")]
    public string? Nombres { get; set; }
    [Required (ErrorMessage ="Favor colocar un numero") ]
    public string? WhatsApp {  get; set; }
}