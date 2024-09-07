using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroTecnicos.Models
{
    public class Tecnicos
    {
        [Key]
       public int TecnicoID { get; set;}
        [Required(ErrorMessage = " El Campo Descripci&oacute;n es obligatorio")]
        public string? Nombres { get; set; }
       public decimal SueldoHora { get; set; }

        [ForeignKey("Tipostecnicos")]
        public int TipoId { get; set; }
        public Tipostecnicos? Tipostecnicos { get; set; }
    }
}
