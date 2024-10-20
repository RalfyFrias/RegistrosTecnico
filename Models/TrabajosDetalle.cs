using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class TrabajosDetalle
    {
        [Key]
        public int DetalleId { get; set; }
        public int TrabajoId { get; set; }

        [ForeignKey("TrabajoId")]
        public Trabajos Trabajo { get; set; }

        public int ArticuloId { get; set; }
        [ForeignKey("ArticuloId")]
        public Articulos Articulo { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]

        public int Cantidad { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio y debe ser mayor a cero .")]
       
        public decimal Precio { get; set; }

        public decimal Costo { get; set; }

    }
}
