using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class Tecnico
    {
        [Key]
       public int TecnicoID { get; set;}
        [Required(ErrorMessage = " El Campo Descripci&oacute;n es obligatorio")]
        public string? Nombres { get; set; }
       public int SueldoHora { get; set; }
    }
}
